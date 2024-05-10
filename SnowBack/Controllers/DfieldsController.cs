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
    public class DfieldsController : Controller
    {
        private readonly SnowmansContext _context;

        public DfieldsController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: Dfields
        [HttpGet]
        [Route("infra/fields/index")]
        public async Task<List<DDfieldsType>> Index()
        {
            return await _context.DDfieldsTypes.ToListAsync();
        }

        // GET: Dfields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDfieldsType = await _context.DDfieldsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dDfieldsType == null)
            {
                return NotFound();
            }

            return View(dDfieldsType);
        }

        // GET: Dfields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dfields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Guid,Name,Code,Description")] DDfieldsType dDfieldsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dDfieldsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dDfieldsType);
        }

        // GET: Dfields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDfieldsType = await _context.DDfieldsTypes.FindAsync(id);
            if (dDfieldsType == null)
            {
                return NotFound();
            }
            return View(dDfieldsType);
        }

        // POST: Dfields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Name,Code,Description")] DDfieldsType dDfieldsType)
        {
            if (id != dDfieldsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dDfieldsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DDfieldsTypeExists(dDfieldsType.Id))
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
            return View(dDfieldsType);
        }

        // GET: Dfields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dDfieldsType = await _context.DDfieldsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dDfieldsType == null)
            {
                return NotFound();
            }

            return View(dDfieldsType);
        }

        // POST: Dfields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dDfieldsType = await _context.DDfieldsTypes.FindAsync(id);
            if (dDfieldsType != null)
            {
                _context.DDfieldsTypes.Remove(dDfieldsType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DDfieldsTypeExists(int id)
        {
            return _context.DDfieldsTypes.Any(e => e.Id == id);
        }
    }
}
