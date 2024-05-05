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
        //public async Task<IActionResult> Create([Bind("ParentId,Name,Description,Location,Executor,Priority,IsGroup,Created,PlanTimeToFinish")] MTask mTask)
        public async Task<IActionResult> Create([FromBody] MTask mTask)
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
                    dTask.Created = mTask.Created;
                    _context.DTasks.Add(dTask);

                    await _context.SaveChangesAsync();
                    task = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == mTask.Name);
                }

                JTask jTask = new JTask();
                jTask.IsGroup = mTask.IsGroup;
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

        // POST: Task/CreateGroup
        [HttpPost]
        [Route("api/task/CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] MGroupTask mGTask)
        {
            if (ModelState.IsValid)
            {
                // проверяем наличие в справочнике DGroup
                var task = await _context.DGroups.FirstOrDefaultAsync(x => x.Name == mGTask.Name);
                // если нет, но добавляем, если есть, то подтягивает информацию
                if (task == null)
                {
                    DGroupTask dGTask = new DGroupTask();
                    dGTask.Name = mGTask.Name;
                    _context.DGroups.Add(dGTask);

                    await _context.SaveChangesAsync();
                    task = await _context.DGroups.FirstOrDefaultAsync(x => x.Name == mGTask.Name);
                }

                foreach (var j in mGTask.Tasks)
                {
                    // проверяем наличие в справочнике DTask
                    var dtask = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == j.Name);
                    // если нет, но добавляем, если есть, то подтягивает информацию
                    if (dtask == null)
                    {
                        DTask dTask = new DTask();
                        dTask.Name = j.Name;
                        dTask.Created = j.Created;
                        _context.DTasks.Add(dTask);

                        await _context.SaveChangesAsync();
                        dtask = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == j.Name);
                    }

                    JTask jTask = new JTask();
                    jTask.IsGroup = j.IsGroup;
                    jTask.GroupId = task.Id;
                    jTask.Task = dtask.Id;
                    jTask.Executor = j.Executor;
                    jTask.Description = j.Description;
                    jTask.Emergency = j.Priority.ToString();
                    jTask.Dateon = j.Created;
                    jTask.Dateoff = j.PlanTimeToFinish;
                    _context.JTasks.Add(jTask);
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // GET: Task/GetList
        [HttpGet]
        [Route("api/task/GetList")]
        public async Task<List<MTask>> GetList(int? userId)
        {
            if (userId == null)
            {
                return null;
            }

            List<JTask> jList = await _context.JTasks.Where(e => e.Executor == userId && e.IsGroup == false).ToListAsync();
            List<MTask> tasksList = new List<MTask>();

            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask {ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
                tasksList.Add(task);
            }

            tasksList = tasksList.OrderBy(x => "Red").ThenBy(x => "Yellow").ThenBy(x => "Green").ToList();

            return tasksList;
        }

        // GET: Task/GetGroupList
        [HttpGet]
        [Route("api/task/GetGroupList")]
        public async Task<List<MGroupTask>> GetGroupList(int? userId)
        {
            if (userId == null)
            {
                return null;
            }

            List<JTask> jList = await _context.JTasks.Where(e => e.Executor == userId && e.IsGroup == true).ToListAsync();
            List<MTask> tasksList = new List<MTask>();
            List<MGroupTask> gTasksList = new List<MGroupTask>();

            // составляем list заданий
            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask { ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
                tasksList.Add(task);
            }

            // TODO: вернуть кусок кода

            tasksList = tasksList.OrderBy(x => "Red").ThenBy(x => "Yellow").ThenBy(x => "Green").ToList();

            return gTasksList;
        }
    }
}