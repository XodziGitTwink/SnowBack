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
        public async Task<List<DStaffModel>> GetList()
        {
            List<DStaff> staffList = await _context.DStaffs.ToListAsync();
            List<DStaffModel> res = new List<DStaffModel>();
            foreach (DStaff staff in staffList)
            {
                res.Add(new DStaffModel { Code = staff.Code, Id = staff.Id, CallId = staff.CallId, Email = staff.Email, Lastname = staff.Lastname, Name = staff.Name, Phone = staff.Phone, Surename = staff.Surename });
            }
            return res;
        }
    }
}
