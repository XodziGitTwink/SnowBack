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

        #region GET

        // GET: DInfraElements
        [HttpGet]
        [Route("infra/elements/index")]
        public async Task<List<DInfraElement>> Index()
        {
           // var snowmansContext = _context.DInfraElements.Include(d => d.TypeNavigation);
            var elements = await _context.DInfraElements.ToListAsync();
           
            return await _context.DInfraElements.ToListAsync();
        }

        // GET: DInfraElements/Details/5
        [HttpGet]
        [Route("infra/elements/index/{id}")]
        public async Task<DInfraElement> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var dInfraElement = await _context.DInfraElements
                //.Include(d => d.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (dInfraElement == null)
            {
                return null;
            }
            var fields = await _context.DInfraElementsFields.Where(x => x.Type == dInfraElement.Type).ToListAsync();
            return dInfraElement;
        }

        [HttpGet]
        [Route("infra/elements/get")]
        public async Task<List<DInfraElementWithFields>> IndexFields()
        {
            var elements = await _context.DInfraElements.ToListAsync();
            List<DInfraElementWithFields> elements_with_fields = new List<DInfraElementWithFields>();

            foreach (var elem in elements)
            {
                var fields = await _context.DInfraElementsFields.Where(x => x.Type == elem.Type).ToListAsync();
                elements_with_fields.Add(new DInfraElementWithFields { Element = elem, DInfraElementsFields = fields });
            }
            return elements_with_fields;
            
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("infra/create")]
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

        [HttpPost]
        [Route("infra/addproperty/")]
        public async Task<IActionResult> AddProperty([Bind("Id,Guid,Name,Code,Type,Dateon,Value,FieldType")] DInfraElementsField dInfraElementsField)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dInfraElementsField);
                await _context.SaveChangesAsync();
                return Ok();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["FieldType"] = new SelectList(_context.DDfieldsTypes, "Id", "Id", dInfraElementsField.FieldType);
            ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id", dInfraElementsField.Type);
            return NotFound();
        }

        #endregion

        #region Delete
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

        #endregion

        private bool DInfraElementExists(int id)
        {
            return _context.DInfraElements.Any(e => e.Id == id);
        }
    }
}
