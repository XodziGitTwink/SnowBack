using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class TasksController : Controller
    {
        private readonly SnowmansContext _context;

        public TasksController(SnowmansContext context)
        {
            _context = context;
        }

        // POST: Task/Create
        [HttpPost]
        [Route("api/task/Create")]
        public async Task<IActionResult> Create([Bind("Guid,Code,Name,Position,Type,Duration,Created")] DTask dTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dTask);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        //// GET: Task/Get
        //[HttpGet]
        //[Route("api/task/GetList")]
        //public async Task<IActionResult> GetList(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    List<DTask> tasksList;

        //    return Ok();
        //}
    }
}