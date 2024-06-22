﻿using Microsoft.AspNetCore.Http.HttpResults;
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
       

        // GET: /setReserved
        //[HttpGet]
        //[Route("setReserved/{userId?}/{tmcId}")]
        //public async Task<IActionResult> SetReserved(int? userId, int tmcId)
        //{
        //    DTMC tmc = await _context.DTmcs.FirstOrDefaultAsync(x => x.UserId == null && x.IsRederved == false && x.IsUsed == false);

        //    foreach (DTMC tmc in TMCList)
        //    {
        //        var shelf = await _context.DShelfs.FirstOrDefaultAsync(x => x.Id == tmc.ShelfId);
        //        var rack = await _context.DRacks.FirstOrDefaultAsync(x => x.Id == shelf.RackId);
        //        var room = await _context.DRooms.FirstOrDefaultAsync(x => x.Id == rack.RoomId);
        //        var stock = await _context.DStocks.FirstOrDefaultAsync(x => x.Id == room.StockId);
        //        myTMCList.Add(new DTMCModel
        //        {
        //            Id = tmc.Id,
        //            Guid = tmc.Guid,
        //            Name = tmc.Name,
        //            Description = tmc.Description,
        //            Code = tmc.Code,
        //            Inventorycode = tmc.Inventorycode,
        //            TypeId = tmc.TypeId,
        //            FunctId = tmc.FunctId,
        //            ShelfId = tmc.ShelfId,
        //            UserId = tmc.UserId,
        //            TaskId = tmc.TaskId,
        //            IsRederved = tmc.IsRederved,
        //            IsUsed = tmc.IsUsed,
        //            StockName = stock.StockName,
        //            RoomName = room.RoomName,
        //            RackName = rack.RackName,
        //            ShelfName = shelf.ShelfName
        //        });
        //    }

        //    return myTMCList;
        //}
    }
}
