using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class TransportFuelingsController : Controller
    {
        private readonly SnowmansContext _context;

        public TransportFuelingsController(SnowmansContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("transport/get")]
        public async Task<List<JTransportFueling>> Index()
        {
            return await _context.JTransportFuelings.ToListAsync();
        }

        [HttpPost]
        [Route("transport/fuel")]
        public async Task<IActionResult> Create([FromBody] JTransportFueling jTransportFueling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jTransportFueling);
                await _context.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        private bool JTransportFuelingExists(int id)
        {
            return _context.JTransportFuelings.Any(e => e.Id == id);
        }
    }
}
