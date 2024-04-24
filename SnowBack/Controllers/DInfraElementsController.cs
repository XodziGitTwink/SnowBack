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
    public class DInfraElementsController : Controller
    {
        private readonly SnowmansContext _context;

        public DInfraElementsController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: DInfraElements
        [HttpGet]
        [Route("infra/index")]
        public async Task<List<DInfraElement>> Index()
        {
           // var snowmansContext = _context.DInfraElements.Include(d => d.TypeNavigation);
            var elements = await _context.DInfraElements.ToListAsync();
           
            return await _context.DInfraElements.ToListAsync();
        }

        // GET: DInfraElements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElement = await _context.DInfraElements
                .Include(d => d.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dInfraElement == null)
            {
                return NotFound();
            }

            return View(dInfraElement);
        }

        // GET: DInfraElements/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id");
            return View();
        }

        // POST: DInfraElements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Guid,Name,Code,Inventorycode,Gps,Type,Description")] DInfraElement dInfraElement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dInfraElement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id", dInfraElement.Type);
            return View(dInfraElement);
        }

        // GET: DInfraElements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElement = await _context.DInfraElements.FindAsync(id);
            if (dInfraElement == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id", dInfraElement.Type);
            return View(dInfraElement);
        }

        // POST: DInfraElements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Name,Code,Inventorycode,Gps,Type,Description")] DInfraElement dInfraElement)
        {
            if (id != dInfraElement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dInfraElement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DInfraElementExists(dInfraElement.Id))
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
            ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id", dInfraElement.Type);
            return View(dInfraElement);
        }

        // GET: DInfraElements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElement = await _context.DInfraElements
                .Include(d => d.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dInfraElement == null)
            {
                return NotFound();
            }

            return View(dInfraElement);
        }

        // POST: DInfraElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dInfraElement = await _context.DInfraElements.FindAsync(id);
            if (dInfraElement != null)
            {
                _context.DInfraElements.Remove(dInfraElement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DInfraElementExists(int id)
        {
            return _context.DInfraElements.Any(e => e.Id == id);
        }
    }
}
