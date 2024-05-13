using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
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
                var fields = await _context.DInfraElementsFields.Where(x => x.Type == elem.Type && x.ElementId == elem.Id).ToListAsync();
                elements_with_fields.Add(new DInfraElementWithFields { Element = elem, DInfraElementsFields = fields });
            }
            return elements_with_fields;
            
        }
        [HttpGet]
        [Route("infra/elements/getchild/{parent_id}")]
        public async Task<List<DInfraElementWithFields>> GetChild(int parent_id)
        {
            
            List<DInfraElement> elements = new List<DInfraElement>();
            List<DInfraElementWithFields> elements_with_fields = new List<DInfraElementWithFields>();

            List<int?> childs_id = await _context.DInfraElementsParents.Where(x => x.Parentid == parent_id).Select(x => x.Objectid).ToListAsync();

            foreach (var id in childs_id)
            {
                var elem = await _context.DInfraElements.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (elem == null) continue;
                elements.Add(elem);
            }

            foreach (var elem in elements)
            {
                var fields = await _context.DInfraElementsFields.Where(x => x.Type == elem.Type && x.ElementId == elem.Id).ToListAsync();
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
            return fields.DistinctBy(x => x.Name).ToList();

        }
        #endregion

        #region Create


        [HttpPost]
        [Route("infra/elements/create-newtype/{parentid?}")]
        public async Task<IActionResult> CreateNewType([FromBody] ElementWithFieldsAndType dInfraElement, int? parentid)
        {
            if (ModelState.IsValid)
            {
                var type = dInfraElement.DInfraElementsType;
                _context.Add(type);
                await _context.SaveChangesAsync();
                var elem = dInfraElement.Element;
                elem.Type = type.Id;
                _context.Add(elem);
                await _context.SaveChangesAsync();
                if (parentid != null)
                {
                    _context.Add(new DInfraElementsParent { Objectid = elem.Id, Parentid = parentid });
                    await _context.SaveChangesAsync();
                }
                foreach (var field in dInfraElement.DInfraElementsFields)
                {
                    field.Type = type.Id;
                    field.ElementId = elem.Id;
                    _context.Add(field);
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("infra/elements/create/{parentid?}")]
        public async Task<IActionResult> Create([FromBody] DInfraElementWithFields dInfraElement, int? parentid)
        {
            try
            {
                var elem = dInfraElement.Element;
                _context.Add(elem);
                await _context.SaveChangesAsync();
                if(parentid != null)
                {
                    _context.Add(new DInfraElementsParent { Objectid = elem.Id, Parentid = parentid});
                    await _context.SaveChangesAsync();
                }
                foreach (var field in dInfraElement.DInfraElementsFields)
                {
                    //field.FieldType = 1;
                    //field.Id = null;
                    field.ElementId = elem.Id;
                    _context.Add(field);
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
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
                //.Include(d => d.TypeNavigation)
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
