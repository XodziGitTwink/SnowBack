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
    public class JEmployeesSchedulesController : Controller
    {
        private readonly SnowmansContext _context;

        public JEmployeesSchedulesController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: JEmployeesSchedules
        [HttpGet]
        [Route("schedule/get")]
        public async Task<List<JEmployeesSchedule>> Index()
        {
            //var snowmansContext = _context.JEmployeesSchedules.Include(j => j.EmployeeNavigation).Include(j => j.ShiftNavigation);
            return await _context.JEmployeesSchedules.ToListAsync();
        }
        [HttpGet]
        [Route("schedule/get-by-date/{dateTime}")]
        public async Task<List<JEmployeesSchedule>> GetbyDate(string dateTime)
        {
            //var snowmansContext = _context.JEmployeesSchedules.Include(j => j.EmployeeNavigation).Include(j => j.ShiftNavigation);
            var stop = DateTime.Parse(dateTime).Date;
            return await _context.JEmployeesSchedules.Where(x => x.Date.Date == DateTime.Parse(dateTime).Date).ToListAsync();
        }

        [HttpPost]
        [Route("schedule/create")]
        public async Task<IActionResult> Create([FromBody] List<JEmployeesSchedule> jEmployeesSchedule)
        {
            try
            {
                foreach (var item in jEmployeesSchedule)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                return Created();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: JEmployeesSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jEmployeesSchedule = await _context.JEmployeesSchedules.FindAsync(id);
            if (jEmployeesSchedule == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_context.DStaffs, "Id", "Id", jEmployeesSchedule.Employee);
            ViewData["Shift"] = new SelectList(_context.Shifts, "Id", "Id", jEmployeesSchedule.Shift);
            return View(jEmployeesSchedule);
        }

        // POST: JEmployeesSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Date,Employee,Manager,Shift,Variant,Type")] JEmployeesSchedule jEmployeesSchedule)
        {
            if (id != jEmployeesSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jEmployeesSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JEmployeesScheduleExists(jEmployeesSchedule.Id))
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
            ViewData["Employee"] = new SelectList(_context.DStaffs, "Id", "Id", jEmployeesSchedule.Employee);
            ViewData["Shift"] = new SelectList(_context.Shifts, "Id", "Id", jEmployeesSchedule.Shift);
            return View(jEmployeesSchedule);
        }

        // GET: JEmployeesSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jEmployeesSchedule = await _context.JEmployeesSchedules
                .Include(j => j.EmployeeNavigation)
                .Include(j => j.ShiftNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jEmployeesSchedule == null)
            {
                return NotFound();
            }

            return View(jEmployeesSchedule);
        }

        // POST: JEmployeesSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jEmployeesSchedule = await _context.JEmployeesSchedules.FindAsync(id);
            if (jEmployeesSchedule != null)
            {
                _context.JEmployeesSchedules.Remove(jEmployeesSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JEmployeesScheduleExists(int id)
        {
            return _context.JEmployeesSchedules.Any(e => e.Id == id);
        }
    }
}
