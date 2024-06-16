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
        [Route("transport/release")]
        public async Task<IActionResult> ToRelease([FromBody] DInfraElementsField field)
        {
            if (ModelState.IsValid)
            {
                if(field.Name == "Rent")
                {
                    field.Value = "0";
                    _context.Update(field);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest("Error field name");
                }
            }
            return BadRequest("Error not valid");
        }

        [HttpPost]
        [Route("transport/rent/{id}")]
        public async Task<IActionResult> ToRent([FromBody] List<DInfraElementsField> fields, int id)
        {
            if (ModelState.IsValid)
            {
                foreach (var field in fields)
                {
                    if (field.Name == "Rent")
                    {
                        field.Value = "1";
                        _context.Update(field);
                        await _context.SaveChangesAsync();
                        continue;
                        
                    }
                    if(field.Name == "UserId")
                    {
                        field.Value=id.ToString();
                        _context.Update(field);
                        await _context.SaveChangesAsync();
                        continue;
                    }
                    else
                    {
                        return BadRequest("Error field name");
                    }
                }
                return Ok();
            }
            return BadRequest("Error not valid");
        }

        [HttpPost]
        [Route("transport/create-function/")]
        public async Task<IActionResult> CreateFunction([FromBody] DInfraElementsFunction dInfraElementsFunction)
        {
            try
            {
                _context.Add(dInfraElementsFunction);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }


        private bool JTransportRentExists(int id)
        {
            return _context.JTransportRents.Any(e => e.Id == id);
        }
    }
}
