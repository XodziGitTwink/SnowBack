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
    public class TransportController : Controller
    {
        private readonly SnowmansContext _context;

        public TransportController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: Transport
        public async Task<List<JTransportRent>> Get()
        {
            return await _context.JTransportRents.ToListAsync();
        }

        // GET: Transport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jTransportRent = await _context.JTransportRents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jTransportRent == null)
            {
                return NotFound();
            }

            return Ok(jTransportRent);
        }

        [HttpPost]
        [Route("transport/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] DInfraElement transport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transport);
                await _context.SaveChangesAsync();
                return Created();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Task,Started,Finished,Element,Point,Executor,Description")] JTransportRent jTransportRent)
        {
            if (id != jTransportRent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jTransportRent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JTransportRentExists(jTransportRent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jTransportRent);
        }

        // GET: Transport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jTransportRent = await _context.JTransportRents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jTransportRent == null)
            {
                return NotFound();
            }

            return View(jTransportRent);
        }


        private bool JTransportRentExists(int id)
        {
            return _context.JTransportRents.Any(e => e.Id == id);
        }
    }
}
