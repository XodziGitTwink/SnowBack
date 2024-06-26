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
    public class SnowGunsController : Controller
    {
        private readonly SnowmansContext _context;

        public SnowGunsController(SnowmansContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("guns/get")]
        public async Task<List<JSnowGunsOrder>> Get()
        {
            return await _context.JSnowGunsOrders.ToListAsync();
        }

        [HttpGet]
        [Route("guns/get-points")]
        public async Task<List<DInfraElement>> GetPoints()
        {
            return await _context.DInfraElements.Where(x => x.Type == 1040).ToListAsync();
        }

        [HttpGet]
        [Route("guns/get-functions")]
        public async Task<List<DInfraElementsFunction>> GetFunctions()
        {
            return await _context.DInfraElementsFunctions.Where(x => x.Type == 1039).ToListAsync();
        }

        [HttpGet]
        [Route("guns/get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var jSnowGunsOrder = await _context.JSnowGunsOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jSnowGunsOrder == null)
            {
                return NotFound();
            }

            return Ok(jSnowGunsOrder);
        }

        [HttpPost]
        [Route("guns/create")]
        public async Task<IActionResult> Create([FromBody] JSnowGunsOrder jSnowGunsOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jSnowGunsOrder);
                await _context.SaveChangesAsync();
                return Ok(jSnowGunsOrder);
            }
            return BadRequest(jSnowGunsOrder);
        }

        [HttpPost]
        [Route("guns/enable")]
        public async Task<IActionResult> Enable([FromBody] JSnowGunsOrder jSnowGunsOrder)
        {
            if (ModelState.IsValid)
            {
                    jSnowGunsOrder.Status = true;
                    _context.Update(jSnowGunsOrder);
                    await _context.SaveChangesAsync();
                    return Ok();
            }
            return BadRequest("Error not valid");
        }

        [HttpPost]
        [Route("guns/disable")]
        public async Task<IActionResult> Disable([FromBody] JSnowGunsOrder jSnowGunsOrder)
        {
            if (ModelState.IsValid)
            {
                jSnowGunsOrder.Status = false;
                _context.Update(jSnowGunsOrder);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Error not valid");
        }

        [HttpPost]
        [Route("guns/edit/")]
        public async Task<IActionResult> Edit([FromBody] JSnowGunsOrder jSnowGunsOrder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jSnowGunsOrder);
                    await _context.SaveChangesAsync();
                    return Ok(jSnowGunsOrder);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JSnowGunsOrderExists(jSnowGunsOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return BadRequest("Error not valid");
        }

        // POST: SnowGuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("guns/delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jSnowGunsOrder = await _context.JSnowGunsOrders.FindAsync(id);
            if (jSnowGunsOrder != null)
            {
                _context.JSnowGunsOrders.Remove(jSnowGunsOrder);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool JSnowGunsOrderExists(int id)
        {
            return _context.JSnowGunsOrders.Any(e => e.Id == id);
        }
    }
}
