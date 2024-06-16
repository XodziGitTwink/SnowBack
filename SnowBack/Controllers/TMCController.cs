using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using SnowBack.Models;

namespace SnowBack.Controllers
{
    public class TMCController : Controller
    {
        private readonly SnowmansContext _context;

        public TMCController(SnowmansContext context)
        {
            _context = context;
        }

        // GET: /getTMCList
        [HttpGet]
        [Route("getTMCList")]
        public async Task<List<DTMCModel>> GetTMCList()
        {
            //List<DTMC> TMCList = await _context.______.Where(x => x.IsReserved == false && x.IsUsed == false).ToListAsync();
            List<DTMCModel> res = new List<DTMCModel>();
            //foreach (DTMC tmc in TMCList)
            //{
            //    res.Add(new DTMCModel {  });
            //}
            return res;
        }

        // GET: /getMyTMCList
        [HttpGet]
        [Route("getMyTMCList/{userId}")]
        public async Task<List<DTMC>> GetMyTMCList(int userId)
        {
            //List<TMC> myTMCList = await _context.______.Where(x => x.UserId == userId && x.IsReserved).ToListAsync();
            List<DTMC> myTMCList = new List<DTMC>();
            return myTMCList;
        }
    }
}
