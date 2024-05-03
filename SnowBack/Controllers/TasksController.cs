using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowBack.Models;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> Create([Bind("ParentId,Name,Description,Location,Executor,Priority,IsGroup,Created,PlanTimeToFinish")] MTask mTask)
        {
            if (ModelState.IsValid)
            {
                // проверяем наличие в справочнике DTask
                var task = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == mTask.Name);
                // если нет, но добавляем, если есть, то подтягивает информацию
                if(task == null)
                {
                    DTask dTask = new DTask();
                    dTask.Name = mTask.Name;
                    dTask.Type = mTask.IsGroup;
                    dTask.Created = mTask.Created;
                    _context.DTasks.Add(dTask);

                    await _context.SaveChangesAsync();
                    task = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == mTask.Name);
                }

                JTask jTask = new JTask();
                jTask.Task = task.Id;
                jTask.Executor = mTask.Executor;
                jTask.Description = mTask.Description;
                jTask.Emergency = mTask.Priority.ToString();
                jTask.Dateon = mTask.Created;
                jTask.Dateoff = mTask.PlanTimeToFinish;
                _context.JTasks.Add(jTask);

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
            List<MTask> tasksList = new List<MTask>();

            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask {ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = dTask.Type, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
                tasksList.Add(task);
            }

            // TODO: возможно надо будет расширить MTask и добавить сортировку по одному из параметров (возможно Сщву)

            return tasksList;
        }
    }
}