using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
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
        public async Task<List<DInfraElementWithFields>> Get()
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

        [HttpGet]
        [Route("infra/elements/get-types")]
        public async Task<List<DInfraElementsType>> GetTypes()
        {
            var types = await _context.DInfraElementsTypes.ToListAsync();
            return types;

        }

        [HttpGet]
        [Route("infra/elements/get-fields-by-type/{id}")]
        public async Task<List<DInfraElementsField>> GetFields(int id)
        {
            var fields = await _context.DInfraElementsFields.Where(x => x.Type == id).ToListAsync();
            return fields;

        }
        #endregion

        #region Create
        //[HttpPost]
        //[Route("infra/create")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Guid,Name,Code,Inventorycode,Gps,Type,Description")] DInfraElement dInfraElement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(dInfraElement);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Type"] = new SelectList(_context.DInfraElementsTypes, "Id", "Id", dInfraElement.Type);
        //    return View(dInfraElement);
        //}

        [HttpPost]
        [Route("infra/create/newtype")]
        public async Task<IActionResult> CreateNewType(DInfraElementWithFields dInfraElement, DInfraElementsType type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(type);
                dInfraElement.Element.Type = type.Id;
                dInfraElement.Element.TypeNavigation = type;
                _context.Add(dInfraElement.Element);
                
                foreach(var field in dInfraElement.DInfraElementsFields)
                {
                    field.Type = type.Id;
                    field.TypeNavigation = type;
                    _context.Add(field);
                }
                await _context.SaveChangesAsync();
                return Created();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("infra/create/")]
        public async Task<IActionResult> Create(DInfraElementWithFields dInfraElement, DInfraElementsType type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dInfraElement.Element);

                foreach (var field in dInfraElement.DInfraElementsFields)
                {
                    _context.Add(field);
                }
                await _context.SaveChangesAsync();
                return Created();
            }
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

        #region Edit
        [HttpPost]
        [Route("infra/elements/edit/")]
        public async Task<IActionResult> Edit([FromBody]DInfraElementWithFields dInfraElement)
        {
                try
                {
                    _context.Update(dInfraElement.Element);
                foreach (var field in dInfraElement.DInfraElementsFields)
                {
                    _context.Update(field);
                }
                await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            return Ok();
        }

        #endregion

        private bool DInfraElementExists(int id)
        {
            return _context.DInfraElements.Any(e => e.Id == id);
        }
    }
}
