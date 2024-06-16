using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class GetStaffController : Controller
    {
        private readonly SnowmansContext _context;

        public GetStaffController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: /gatStaff
        [HttpGet]
        [Route("getStaff")]
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

        // GET: /getRoleByPhone
        [HttpGet]
        [Route("getRoleByPhone/{id}")]
        public async Task<int?> GetRoleByPhone(int id)
        {
            var user = await _context.DStaffs.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return 0;
            }
            return user.Position;
        }

        // GET: /getExecutorDocs
        [HttpGet]
        [Route("getExecutorDocs/{executorId}")]
        public async Task<List<string>> GetExecutorDocs(int executorId)
        {
            var executorDocsList = new List<string>();
            var docsList = await _context.DStaffKbs.Where(x => x.Relatedobject == executorId).ToListAsync();
            foreach (var link in docsList)
            {
                executorDocsList.Add(link.Filepath);
            }
            return executorDocsList;
        }
    }
}
