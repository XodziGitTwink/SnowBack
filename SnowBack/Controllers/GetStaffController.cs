using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class GetStaffController
    {
        private readonly SnowmansContext _context;

        public GetStaffController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: /gatStaff
        [HttpGet]
        [Route("api/getStaff")]
        public async Task<List<DStaff>> GetList()
        {
            List<DStaff> staffList = await _context.DStaffs.ToListAsync();

            return staffList;
        }
    }
}
