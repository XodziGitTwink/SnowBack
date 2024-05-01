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
    public class TasksController : Controller
    {
        private readonly SnowmansContext _context;

        public TasksController(SnowmansContext context)
        {
            _context = context;
        }

        // POST: Task/Create
        [HttpPost]
        [Route("api/task/Create")]
        public async Task<IActionResult> Create([Bind("Name,Description,Location,Executor,Priority,PlanTimeToFinish")] MTask mTask)
        {
            if (ModelState.IsValid)
            {
                // проверяем наличие в справочнике DTask
                var task = await _context.DTasks.SingleOrDefaultAsync(x => x.Name == mTask.Name);
                // если нет, но добавляем, если есть, то подтягивает информацию
                if(task == null)
                {
                    task.Name = mTask.Name;

                    JTask jTask = new JTask();
                    jTask.Task = task.Id;
                    jTask.Executor = mTask.Executor;
                    //jTask.Description = mTask.Description;
                    jTask.Emergency = mTask.Priority.ToString();
                    jTask.Dateoff = mTask.PlanTimeToFinish;

                    _context.DTasks.Add(task);
                    _context.JTasks.Add(jTask);
                }
                else
                {
                    JTask jTask = new JTask();
                    jTask.Task = task.Id;
                    jTask.Executor = mTask.Executor;
                    //jTask.Description = mTask.Description;
                    jTask.Emergency = mTask.Priority.ToString();
                    jTask.Dateoff = mTask.PlanTimeToFinish;

                    _context.JTasks.Add(jTask);
                }
                
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // GET: Task/Get
        [HttpGet]
        [Route("api/task/GetList")]
        public async Task<List<MTask>> GetList(int? userId)
        {
            if (userId == null)
            {
                return null;
            }

            List<JTask> jList = await _context.JTasks.Where(e => e.Executor == userId || e.Executor == null).ToListAsync();
            //List<DTask> dList = await _context.DTasks.Where(e => e.Id == executor).ToListAsync();
            List<MTask> tasksList = new List<MTask>();

            for (int i = 0; i < jList.Count; i++)
            {
                //var task = new MTask {Name = dList[i].Name, Executor = jList[i].Executor, Dateon = jList[i].Dateon, Dateoff = jList[i].Dateoff};
                //tasksList.Add(task);
            }

            // TODO: возможно надо будет расширить MTask и добавить сортировку по одному из параметров (возможно Сщву)

            return tasksList;
        }
    }
}