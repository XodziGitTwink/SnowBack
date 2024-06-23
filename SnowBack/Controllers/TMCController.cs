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
            List<DTmc> TMCList = await _context.DTmcs.Where(x => x.IsRederved == false && x.IsUsed == false).ToListAsync();

            return TMCList;
        }

        // GET: /getMyTMCList
        [HttpGet]
        [Route("getMyTMCList/{userId?}")]
        public async Task<List<DTmcModel>> GetMyTMCList(int? userId)
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
                    IsActive = tmc.IsActive,
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
       [Route("setReserved/{userId?}/{tmcId}")]
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
            tmc.IsActive = false;
            tmc.IsRederved = false;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /setTask
        [HttpGet]
        [Route("setTask/{userId}/{tmcId}")]
        public async Task<IActionResult> SetTask(int userId, int tmcId)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Executor == userId && x.IsComplete == false && x.IsActive == true);

            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId);

            if (tmc == null || jTask == null)
            {
                return BadRequest();
            }

            tmc.TaskId = jTask.Id;
            tmc.IsActive = true;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /unsetTask
        [HttpGet]
        [Route("unsetTask/{tmcId}")]
        public async Task<IActionResult> UnsetTask(int tmcId)
        {
            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.TaskId = null;
            tmc.IsActive = false;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /setUsed
        [HttpGet]
        [Route("setUsed/{tmcId}")]
        public async Task<IActionResult> SetUsed(int tmcId)
        {
            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId && x.IsRederved && x.UserId != null && x.TaskId != null);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.IsUsed = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
