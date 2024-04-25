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
    public class DInfraElementsTypesController : Controller
    {
        private readonly SnowmansContext _context;

        public DInfraElementsTypesController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: DInfraElementsTypes
        [HttpGet]
        [Route("infra/types/get")]
        public async Task<List<DInfraElementsType>> Index()
        {
            return await _context.DInfraElementsTypes.ToListAsync();
        }

        #region Also

        // GET: DInfraElementsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElementsType = await _context.DInfraElementsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dInfraElementsType == null)
            {
                return NotFound();
            }

            return View(dInfraElementsType);
        }

        // GET: DInfraElementsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DInfraElementsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Guid,Name,Code,Description")] DInfraElementsType dInfraElementsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dInfraElementsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dInfraElementsType);
        }

        // GET: DInfraElementsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElementsType = await _context.DInfraElementsTypes.FindAsync(id);
            if (dInfraElementsType == null)
            {
                return NotFound();
            }
            return View(dInfraElementsType);
        }

        // POST: DInfraElementsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Name,Code,Description")] DInfraElementsType dInfraElementsType)
        {
            if (id != dInfraElementsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dInfraElementsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DInfraElementsTypeExists(dInfraElementsType.Id))
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
            return View(dInfraElementsType);
        }

        // GET: DInfraElementsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dInfraElementsType = await _context.DInfraElementsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dInfraElementsType == null)
            {
                return NotFound();
            }

            return View(dInfraElementsType);
        }

        // POST: DInfraElementsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dInfraElementsType = await _context.DInfraElementsTypes.FindAsync(id);
            if (dInfraElementsType != null)
            {
                _context.DInfraElementsTypes.Remove(dInfraElementsType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        private bool DInfraElementsTypeExists(int id)
        {
            return _context.DInfraElementsTypes.Any(e => e.Id == id);
        }
    }
}
