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
    public class StaffController : Controller
    {
        private readonly SnowmansContext _context;

        public StaffController(SnowmansContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("staff/get")]
        public async Task<List<DStaff>> Details()
        {
            return await _context.DStaffs.ToListAsync();
        }

        // GET: Staff/Details/5
        public async Task<DStaff?> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var dStaff = await _context.DStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dStaff == null)
            {
                return null;
            }

            return dStaff;
        }


        [HttpPost]
        [Route("staff/create/{position}")]
        public async Task<IActionResult> Create([FromBody] DStaff dStaff, int position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dStaff);
                await _context.SaveChangesAsync();
                try
                {
                    JStaffAssign jStaffAssign = new JStaffAssign { Employee = dStaff.Id, Position = position, Hired = DateOnly.FromDateTime(DateTime.Now)};
                    _context.Add(jStaffAssign);
                    await _context.SaveChangesAsync();
                }
                catch
                {

                    return NotFound();
                }
                return Created();
            }
            return NotFound();
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dStaff = await _context.DStaffs.FindAsync(id);
            if (dStaff == null)
            {
                return NotFound();
            }
            return View(dStaff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surename,Lastname,Code,CallId,Phone,Email")] DStaff dStaff)
        {
            if (id != dStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DStaffExists(dStaff.Id))
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
            return View(dStaff);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dStaff = await _context.DStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dStaff == null)
            {
                return NotFound();
            }

            return View(dStaff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dStaff = await _context.DStaffs.FindAsync(id);
            if (dStaff != null)
            {
                _context.DStaffs.Remove(dStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DStaffExists(int id)
        {
            return _context.DStaffs.Any(e => e.Id == id);
        }
    }
}
