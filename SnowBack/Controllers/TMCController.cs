using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using SnowBack.Models;

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
            var shelfsList = await _context.DShelfs.ToListAsync();
            var racksList = await _context.DRacks.ToListAsync();
            var roomsList = await _context.DRooms.ToListAsync();
            var stocksList = await _context.DStocks.ToListAsync();

            foreach (DTmc tmc in TMCList)
            {
                DShelf shelf = (DShelf)shelfsList.Where(x => x.Id == tmc.ShelfId);
                DRack rack = (DRack)racksList.Where(x => x.Id == shelf.RackId);
                DRoom room = (DRoom)roomsList.Where(x => x.Id == rack.RoomId);
                DStock stock = (DStock)stocksList.Where(x => x.Id == room.StockId);
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
            var shelfsList = await _context.DShelfs.ToListAsync();
            var racksList = await _context.DRacks.ToListAsync();
            var roomsList = await _context.DRooms.ToListAsync();
            var stocksList = await _context.DStocks.ToListAsync();

            foreach (DTmc tmc in TMCList)
            {
                DShelf shelf = (DShelf)shelfsList.Where(x => x.Id == tmc.ShelfId);
                DRack rack = (DRack)racksList.Where(x => x.Id == shelf.RackId);
                DRoom room = (DRoom)roomsList.Where(x => x.Id == rack.RoomId);
                DStock stock = (DStock)stocksList.Where(x => x.Id == room.StockId);
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
                    StockName = shelfsList.StockName,
                    RoomName = racksList.RoomName,
                    RackName = roomsList.RackName,
                    ShelfName = stocksList.ShelfName
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
            tmc.IsRederved = false;

            await _context.SaveChangesAsync();

            return Ok();
        }

        //GET: /setTask
        [HttpGet]
        [Route("setTask/{taskId?}/{tmcId}")]
        public async Task<IActionResult> SetTask(int? taskId, int tmcId)
        {
            DTmc tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.Id == tmcId);

            if (tmc == null)
            {
                return BadRequest();
            }

            tmc.TaskId = taskId;

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
