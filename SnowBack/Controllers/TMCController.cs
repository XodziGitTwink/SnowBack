using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration.UserSecrets;
using SnowBack.Models;
using System;

namespace SnowBack.Controllers
{
    public class TMCController : Controller
    {
        private readonly SnowmansContext _context;

        public TMCController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: /getGoodList
        [HttpGet]
        [Route("getGoodList")]
        public async Task<List<GoodModel>> GetGoodList()
        {
            List<DGood> DGoodsList = await _context.DGoods.Where(x => x.Remain > 0).ToListAsync();
            List<GoodModel> GoodsList = new List<GoodModel>();

            foreach (DGood good in DGoodsList)
            {
                var jGoood = await _context.JGoods.FirstOrDefaultAsync(x => x.Good == good.Id);
                var dGoodType = await _context.DGoodsTypes.FirstOrDefaultAsync(x => x.Id == good.Type);
                GoodModel newGood = new GoodModel();
                newGood.Good = good;
                newGood.GoodInfo = jGoood;
                newGood.GoodType = dGoodType;
                GoodsList.Add(newGood);
            }

            return GoodsList;
        }

        // GET: /getMyGoodsList
        [HttpGet]
        [Route("getMyGoodsList/{userId}")]
        public async Task<List<GoodModel>> GetMyGoodsList(int userId)
        {
            List<DGood> DGoodsList = await _context.DGoods.ToListAsync();
            List<GoodModel> myGoodsList = new List<GoodModel>();

            foreach (DGood good in DGoodsList)
            {
                var jGoodList = await _context.JGoods
                                  .Where(x => x.Good == good.Id && x.UserWho == userId && x.Task == null && x.Type == true && x.Destination == null && x.DestinationAddr == null && x.Deleted == false)
                                  .ToListAsync();
                if (jGoodList.Count == 0) continue;
                var dGoodType = await _context.DGoodsTypes.FirstOrDefaultAsync(x => x.Id == good.Type);
                foreach (JGood jgood in jGoodList)
                {
                    GoodModel newGood = new GoodModel();
                    newGood.Good = good;
                    newGood.GoodInfo = jgood;
                    newGood.GoodType = dGoodType;
                    myGoodsList.Add(newGood);
                }
            }

            return myGoodsList;
        }

        // POST: good/Create
        [HttpPost]
        [Route("good/Create")]
        public async Task<IActionResult> Create([FromBody] GoodModel goodModel)
        {
            if (ModelState.IsValid)
            {
                var dGood = await _context.DGoods.FirstOrDefaultAsync(x => x.Name == goodModel.Good.Name && x.Type == goodModel.Good.Type);

                if (dGood == null)
                {
                    goodModel.Good.DateOn = DateTime.Now;
                    _context.DGoods.Add(goodModel.Good);
                    await _context.SaveChangesAsync();
                    dGood = await _context.DGoods.FirstOrDefaultAsync(x => x.Name == goodModel.Good.Name && x.Type == goodModel.Good.Type);
                }

                var jGood = goodModel.GoodInfo;
                jGood.Good = dGood.Id;
                jGood.Type = false;
                jGood.Destination = goodModel.GoodInfo.Destination;
                jGood.DestinationAddr = goodModel.GoodInfo.DestinationAddr;
                jGood.DateOn = DateTime.Now;
                jGood.Deleted = false;

                _context.JGoods.Add(jGood);
                await _context.SaveChangesAsync();

                await RemainRecalculation(dGood.Id);

                await _context.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        //POST: /reserving
        [HttpPost]
        [Route("reserving")]
        public async Task<IActionResult> Reserving([FromBody] GoodModel goodModel)
        {
            var jGoodModel = goodModel.GoodInfo;
            jGoodModel.Id = 0;
            jGoodModel.DateOn = DateTime.Now;
            jGoodModel.Deleted = false;
            _context.JGoods.Add(jGoodModel);
            await _context.SaveChangesAsync();

            await RemainRecalculation(goodModel.Good.Id);

            await _context.SaveChangesAsync();

            return Ok();
        }

        //POST: /returning
        [HttpPost]
        [Route("returning")]
        public async Task<IActionResult> Returning([FromBody] GoodModel goodModel)
        {
            var jGoodModel = goodModel.GoodInfo;
            jGoodModel.Id = 0;
            var jGood = await _context.JGoods
                                  .Where(x => x.Good == goodModel.Good.Id && x.UserWho == jGoodModel.UserWho && x.Type == true && x.Qty == jGoodModel.Qty && x.Deleted == false)
                                  .OrderByDescending(x => x.DateOn)
                                  .LastOrDefaultAsync();

            jGood.Deleted = true;
            jGood.DelUser = jGoodModel.UserWho;
            jGoodModel.DateOn = DateTime.Now;
            jGood.DelDate = jGoodModel.DateOn;
            _context.JGoods.Add(jGoodModel);
            await _context.SaveChangesAsync();

            await RemainRecalculation(goodModel.Good.Id);

            await _context.SaveChangesAsync();

            return Ok();
        }

        //POST: /writingOff
        [HttpPost]
        [Route("writingOff")]
        public async Task<IActionResult> WritingOff([FromBody] GoodModel goodModel)
        {
            var jGoodModel = goodModel.GoodInfo;
            jGoodModel.Id = 0;
            var dGood = await _context.DGoods.FirstOrDefaultAsync(x => x.Id == goodModel.Good.Id);
            var jGood = await _context.JGoods
                                  .Where(x => x.Good == goodModel.Good.Id && x.UserWho == jGoodModel.UserWho && x.Type == true && x.Qty == jGoodModel.Qty && x.Deleted == false)
                                  .OrderByDescending(x => x.DateOn)
                                  .LastOrDefaultAsync();
            if (jGood == null)
            {
                jGoodModel.DateOn = DateTime.Now;
                _context.JGoods.Add(jGoodModel);
                await _context.SaveChangesAsync();
                await RemainRecalculation(goodModel.Good.Id);
            }
            else
            {
                jGood.Deleted = true;
                jGood.DelUser = jGoodModel.UserWho;
                jGoodModel.DateOn = DateTime.Now;
                jGood.DelDate = jGoodModel.DateOn;
                dGood.DateOn = DateTime.Now;
                _context.JGoods.Add(jGoodModel);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        // метод перерасчёта остатка
        public async Task RemainRecalculation(int goodId)
        {
            var dGood = await _context.DGoods.FirstOrDefaultAsync(x => x.Id == goodId);

            var replenishmentList = await _context.JGoods.Where(x => x.Type == false && x.Good == goodId && x.SourceAddr != null && x.DestinationAddr != null && x.DateOn >= dGood.DateOn).ToListAsync();
            var reservedList = await _context.JGoods.Where(x => x.Type == true && x.Good == goodId && x.Task == null && x.DestinationAddr == null && x.DateOn > dGood.DateOn).ToListAsync();
            var writingOffList = await _context.JGoods.Where(x => x.Type == true && x.Good == goodId && x.Task != null && x.DestinationAddr != null && x.DateOn > dGood.DateOn).ToListAsync();

            // добавляем новые приходы с момента последнего перерасчёта
            foreach (var item in replenishmentList)
            {
                dGood.Remain += item.Qty;
            }

            // вычитаем новые резервации с момента последнего перерасчёта
            foreach (var item in reservedList)
            {
                dGood.Remain -= item.Qty;
            }

            // вычитаем новые приходы с момента последнего перерасчёта
            foreach (var item in writingOffList)
            {
                dGood.Remain -= item.Qty;
            }

            dGood.DateOn = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
