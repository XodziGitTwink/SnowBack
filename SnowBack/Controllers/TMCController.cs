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

        // POST: tmc/Create
        [HttpPost]
        [Route("tmc/Create")]
        public async Task<IActionResult> Create([FromBody] DTmcModel tmcModel)
        {
            if (ModelState.IsValid)
            {
                var tmc = new DTmc();
                tmc.Name = tmcModel.Name;
                tmc.Description = tmcModel.Description;
                tmc.Guid = tmcModel.Guid;
                tmc.Code = tmcModel.Code;
                tmc.Inventorycode = tmcModel.Inventorycode;
                tmc.TypeId = tmcModel.TypeId;
                tmc.FunctId = tmcModel.FunctId;
                tmc.ShelfId = tmcModel.ShelfId;
                tmc.UserId = null;
                tmc.TaskId = null;
                tmc.IsRederved = false;
                tmc.IsUsed = false;
                _context.DTmcs.Add(tmc);

                await _context.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        // GET: tmc/Update
        [HttpGet]
        [Route("tmc/Update")]
        public async Task<IActionResult> Update([FromBody] DTmcModel tmcModel)
        {
            if (ModelState.IsValid)
            {
                var tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcModel.Id);

                if (tmc == null)
                {
                    return BadRequest();
                }

                tmc.Name = tmcModel.Name;
                tmc.Description = tmcModel.Description;
                tmc.Guid = tmcModel.Guid;
                tmc.Code = tmcModel.Code;
                tmc.Inventorycode = tmcModel.Inventorycode;
                tmc.TypeId = tmcModel.TypeId;
                tmc.FunctId = tmcModel.FunctId;
                tmc.ShelfId = tmcModel.ShelfId;
                tmc.UserId = tmcModel.UserId;
                tmc.TaskId = tmcModel.TaskId;
                tmc.IsRederved = tmcModel.IsRederved;
                tmc.IsUsed = tmcModel.IsUsed;

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // GET: /getTMCList
        [HttpGet]
        [Route("getTMCList")]
        public async Task<List<DTmcModel>> GetTMCList()
        {
            List<DTmc> TMCList = await _context.DTmcs.Where(x => x.IsRederved == false && x.IsUsed == false).ToListAsync();
            List<DTmcModel> res = new List<DTmcModel>();

            foreach (DTmc tmc in TMCList)
            {
                var shelf = await _context.DShelfs.FirstOrDefaultAsync(x => x.Id == tmc.ShelfId);
                var rack = await _context.DRacks.FirstOrDefaultAsync(x => x.Id == shelf.RackId);
                var room = await _context.DRooms.FirstOrDefaultAsync(x => x.Id == rack.RoomId);
                var stock = await _context.DStocks.FirstOrDefaultAsync(x => x.Id == room.StockId);
                res.Add(new DTmcModel
                {
                    Id = tmc.Id,
                    Guid = tmc.Guid,
                    Name = tmc.Name,
                    Description = tmc.Description,
                    Code = tmc.Code,
                    Inventorycode = tmc.Inventorycode,
                    TypeId = tmc.TypeId,
                    FunctId = tmc.FunctId,
                    ShelfId = tmc.ShelfId,
                    UserId = tmc.UserId,
                    TaskId = tmc.TaskId,
                    IsRederved = tmc.IsRederved,
                    IsUsed = tmc.IsUsed,
                    StockName = stock.StockName,
                    RoomName = room.RoomName,
                    RackName = rack.RackName,
                    ShelfName = shelf.ShelfName
                });
            }

            return res;
        }

        // GET: /getDTMCList
        [HttpGet]
        [Route("getDTMCList")]
        public async Task<List<DTmc>> GetDTMCList()
        {
            List<DTmc> TMCList = await _context.DTmcs.ToListAsync();

            return TMCList;
        }

        // GET: /getFunctionsList
        [HttpGet]
        [Route("getFunctionsList")]
        public async Task<List<DTmcFunctionModel>> GetFunctionsList()
        {
            var list = await _context.DTmcFunctions.ToListAsync();
            var finalList = new List<DTmcFunctionModel>();
            foreach (var item in list)
            {
                var function = new DTmcFunctionModel();
                function.Id = item.Id;
                function.Guid = item.Guid;
                function.Name = item.Name;
                function.Description = item.Description;
                function.Code = item.Code;
                function.TypeId = item.TypeId;
                finalList.Add(function);
            }

            return finalList;
        }

        // GET: /getTypesList
        [HttpGet]
        [Route("getTypesList")]
        public async Task<List<DTmcTypeModel>> GetTypesList()
        {
            var list = await _context.DTmcTypes.ToListAsync();
            var finalList = new List<DTmcTypeModel>();
            foreach (var item in list)
            {
                var type = new DTmcTypeModel();
                type.Id = item.Id;
                type.Guid = item.Guid;
                type.Name = item.Name;
                type.Description = item.Description;
                type.Code = item.Code;
                finalList.Add(type);
            }

            return finalList;
        }

        // GET: /getStocksList
        [HttpGet]
        [Route("getStocksList")]
        public async Task<List<DStockModel>> GetStocksList()
        {
            var list = await _context.DStocks.ToListAsync();
            var finalList = new List<DStockModel>();
            foreach (var item in list)
            {
                var stock = new DStockModel();
                stock.Id = item.Id;
                stock.StockName = item.StockName;
                stock.StockDesc = item.StockDesc;
                stock.Guid = item.Guid;
                finalList.Add(stock);
            }

            return finalList;
        }

        // GET: /getRoomsList
        [HttpGet]
        [Route("getRoomsList")]
        public async Task<List<DRoomModel>> GetRoomsList()
        {
            var list = await _context.DRooms.ToListAsync();
            var finalList = new List<DRoomModel>();
            foreach (var item in list)
            {
                var room = new DRoomModel();
                room.Id = item.Id;
                room.StockId = item.StockId;
                room.RoomName = item.RoomName;
                room.RoomDescription = item.RoomDescription;
                room.Guid = item.Guid;
                finalList.Add(room);
            }

            return finalList;
        }

        // GET: /getRacksList
        [HttpGet]
        [Route("getRacksList")]
        public async Task<List<DRackModel>> GetRacksList()
        {
            var list = await _context.DRacks.ToListAsync();
            var finalList = new List<DRackModel>();
            foreach (var item in list)
            {
                var rack = new DRackModel();
                rack.Id = item.Id;
                rack.RoomId = item.RoomId;
                rack.RackName = item.RackName;
                rack.RackDescription = item.RackDescription;
                rack.Guid = item.Guid;
                finalList.Add(rack);
            }

            return finalList;
        }

        // GET: /getShelfsList
        [HttpGet]
        [Route("getShelfsList")]
        public async Task<List<DShelfModel>> GetShelfsList()
        {
            var list = await _context.DShelfs.ToListAsync();
            var finalList = new List<DShelfModel>();
            foreach (var item in list)
            {
                var shelf = new DShelfModel();
                shelf.Id = item.Id;
                shelf.RackId = item.RackId;
                shelf.ShelfName = item.ShelfName;
                shelf.ShelfDiscription = item.ShelfDiscription;
                shelf.Guid = item.Guid;
                finalList.Add(shelf);
            }

            return finalList;
        }

        // GET: /getMyTMCList
        [HttpGet]
        [Route("getMyTMCList/{userId}")]
        public async Task<List<DTmcModel>> GetMyTMCList(int userId)
        {
            List<DTmc> TMCList = await _context.DTmcs.Where(x => x.UserId == userId && x.IsRederved && x.IsUsed == false).ToListAsync();
            List<DTmcModel> myTMCList = new List<DTmcModel>();

            foreach (DTmc tmc in TMCList)
            {
                var shelf = await _context.DShelfs.FirstOrDefaultAsync(x => x.Id == tmc.ShelfId);
                var rack = await _context.DRacks.FirstOrDefaultAsync(x => x.Id == shelf.RackId);
                var room = await _context.DRooms.FirstOrDefaultAsync(x => x.Id == rack.RoomId);
                var stock = await _context.DStocks.FirstOrDefaultAsync(x => x.Id == room.StockId);
                myTMCList.Add(new DTmcModel
                {
                    Id = tmc.Id,
                    Guid = tmc.Guid,
                    Name = tmc.Name,
                    Description = tmc.Description,
                    Code = tmc.Code,
                    Inventorycode = tmc.Inventorycode,
                    TypeId = tmc.TypeId,
                    FunctId = tmc.FunctId,
                    ShelfId = tmc.ShelfId,
                    UserId = tmc.UserId,
                    TaskId = tmc.TaskId,
                    IsRederved = tmc.IsRederved,
                    IsUsed = tmc.IsUsed,
                    StockName = stock.StockName,
                    RoomName = room.RoomName,
                    RackName = rack.RackName,
                    ShelfName = shelf.ShelfName
                });
            }

            return myTMCList;
        }

       //GET: /setReserved
       [HttpGet]
       [Route("setReserved/{userId}/{tmcId}")]
        public async Task<IActionResult> SetReserved(int? userId, int tmcId)
        {
            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.UserId = userId;
            tmc.IsRederved = true;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /unsetReserved
        [HttpGet]
        [Route("unsetReserved/{tmcId}")]
        public async Task<IActionResult> UnsetReserved(int tmcId)
        {
            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.UserId = null;
            tmc.TaskId = null;
            tmc.IsRederved = false;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /setUsed
        [HttpGet]
        [Route("setUsed/{userId}/{tmcId}")]
        public async Task<IActionResult> SetUsed(int userId, int tmcId)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Executor == userId && x.IsComplete == false);

            var tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId && x.IsRederved && x.UserId != null && x.TaskId != null);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.TaskId = jTask.Id;
            tmc.IsUsed = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
