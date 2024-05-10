using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class AuthenticationsController : Controller
    {
        private readonly SnowmansContext _context;

        public AuthenticationsController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: Authentications
        [HttpGet]
        [Route("api/index")]
        public async Task<List<DAuthentication>> Index()
        {
            return await _context.DAuthentications.ToListAsync();
        }
        //public async Task<DAuthentication> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new DAuthentication();
        //    }

        //    var dAuthentication = await _context.DAuthentications
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (dAuthentication == null)
        //    {
        //        return new DAuthentication();
        //    }

        //    return dAuthentication;
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route("api/authenticate")]
        public async Task<IActionResult> Authenticate([Bind("Login,Password")] DAuthentication dAuthentication)
        {
            var user = _context.DAuthentications.SingleOrDefault(x => x.Login == dAuthentication.Login && x.Password == dAuthentication.Password);
            
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create([Bind("Login,Password")] DAuthentication dAuthentication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dAuthentication);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dAuthentication = await _context.DAuthentications.FindAsync(id);
        //    if (dAuthentication == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(dAuthentication);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password")] DAuthentication dAuthentication)
        //{
        //    if (id != dAuthentication.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(dAuthentication);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DAuthenticationExists(dAuthentication.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Ok();
        //}

        //// GET: Authentications/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dAuthentication = await _context.DAuthentications
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (dAuthentication == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}

        //// POST: Authentications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var dAuthentication = await _context.DAuthentications.FindAsync(id);
        //    if (dAuthentication != null)
        //    {
        //        _context.DAuthentications.Remove(dAuthentication);
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        //private bool DAuthenticationExists(int id)
        //{
        //    return _context.DAuthentications.Any(e => e.Id == id);
        //}
    }
}
