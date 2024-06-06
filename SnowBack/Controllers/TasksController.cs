using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
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
        [Route("task/Create")]
        //public async Task<IActionResult> Create([Bind("ParentId,Name,Description,Location,Executor,Priority,IsGroup,Created,PlanTimeToFinish")] MTask mTask)
        public async Task<IActionResult> Create([FromBody] MTask mTask)
        {
            if (ModelState.IsValid)
            {
                var task = await _context.DTasks.FirstOrDefaultAsync(x => x.Name == mTask.Name);
                // если нет, но добавляем, если есть, то подтягивает информацию
                if (task == null)
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
                jTask.Creator = mTask.Creator;
                jTask.Description = mTask.Description;
                jTask.Emergency = mTask.Priority.ToString();
                jTask.Dateon = mTask.Created;
                jTask.Dateoff = mTask.PlanTimeToFinish;
                jTask.IsActive = false;
                jTask.IsComplete = false;
                _context.JTasks.Add(jTask);

                await _context.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        // POST: Task/CreateGroup
        [HttpPost]
        [Route("task/CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] MGroupTask mGTask)
        {
            if (ModelState.IsValid)
            {
                DGroupTask dGTask = new DGroupTask();
                dGTask.Name = mGTask.Name;
                dGTask.Description = mGTask.Description;
                dGTask.Created = DateTime.Now;
                dGTask.Creator = mGTask.Creator;
                _context.DGroupTasks.Add(dGTask);

                await _context.SaveChangesAsync();

                dGTask = await _context.DGroupTasks.FirstOrDefaultAsync(x => x.Name == mGTask.Name);

                foreach (var j in mGTask.Tasks)
                {
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
                    jTask.GroupId = dGTask.Id;
                    jTask.Task = dtask.Id;
                    jTask.Executor = j.Executor;
                    jTask.Creator = j.Creator;
                    jTask.Description = j.Description;
                    jTask.Emergency = j.Priority.ToString();
                    jTask.Dateon = j.Created;
                    jTask.Dateoff = j.PlanTimeToFinish;
                    jTask.IsActive = false;
                    jTask.IsComplete = false;
                    _context.JTasks.Add(jTask);
                }

                await _context.SaveChangesAsync();
                return Created();
            }
            return BadRequest();
        }

        // GET: Task/getDTasksList
        [HttpGet]
        [Route("task/getDTasksList")]
        public async Task<List<DTask>> GetDTasksList()
        {
            List<DTask> tasksList = new List<DTask>();
            tasksList = await _context.DTasks.ToListAsync();

            return tasksList;
        }

        //// GET: Task/GetList
        //[HttpGet]
        //[Route("task/GetList")]
        //public async Task<List<MTask>> GetList()
        //{

        //    List<JTask> jList = await _context.JTasks.ToListAsync();
        //    List<MTask> tasksList = new List<MTask>();

        //    for (int i = 0; i < jList.Count; i++)
        //    {
        //        DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
        //        var task = new MTask { Id = jList[i].Id, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff };
        //        tasksList.Add(task);
        //    }

        //    tasksList = tasksList
        //                  .OrderBy(x =>
        //                  {
        //                      // Определяем приоритет в зависимости от значения поля Priority
        //                      switch (x.Priority)
        //                      {
        //                          case "Red": return 1;
        //                          case "Yellow": return 2;
        //                          case "Green": return 3;
        //                          default: return 4; // По умолчанию, если значение Priority не соответствует ожидаемым
        //                      }
        //                  })
        //                  .ToList();

        //    return tasksList;
        //}

        // GET: Task/GetExecutorList
        [HttpGet]
        [Route("task/GetExecutorList/{userId}")]
        public async Task<List<MTask>> GetExecutorList(int userId)
        {
            // тут выводятся все задания, в которых пользователь - исполнитель (и обычные, и дочерние у комплексных)
            List<JTask> jList = await _context.JTasks.Where(e => e.Executor == userId && e.IsComplete == false).ToListAsync();
            List<MTask> tasksExList = new List<MTask>();

            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff };
                tasksExList.Add(task);
            }

            tasksExList = tasksExList
                          .OrderBy(x =>
                          {
                              switch (x.Priority)
                              {
                                  case "Red": return 1;
                                  case "Yellow": return 2;
                                  case "Green": return 3;
                                  default: return 4;
                              }
                          })
                          .ToList();

            return tasksExList;
        }

        //// GET: Task/GetCreatorList
        //[HttpGet]
        //[Route("task/GetCreatorList/{userId}")]
        //public async Task<List<MTask>> GetCreatorList(int userId)
        //{
        //    // тут выводятся задания, в которых пользователь - создатель, исполнитель - другой человек (только обычные)
        //    List<JTask> jList = await _context.JTasks.Where(e => e.Executor != userId && e.Creator == userId && e.IsComplete == false && e.IsGroup == false).ToListAsync();
        //    List<MTask> tasksCreatorList = new List<MTask>();

        //    for (int i = 0; i < jList.Count; i++)
        //    {
        //        DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
        //        var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff };
        //        tasksCreatorList.Add(task);
        //    }

        //    tasksCreatorList = tasksCreatorList
        //                  .OrderBy(x =>
        //                  {
        //                      switch (x.Priority)
        //                      {
        //                          case "Red": return 1;
        //                          case "Yellow": return 2;
        //                          case "Green": return 3;
        //                          default: return 4;
        //                      }
        //                  })
        //                  .ToList();

        //    return tasksCreatorList;
        //}

        // GET: Task/GetAnotherList
        [HttpGet]
        [Route("task/GetAnotherList/{userId}")]
        public async Task<List<MTask>> GetAnotherList(int userId)
        {
            // тут выводятся задания, в которых пользователь не является создателем или исполнителем (только обычные)
            List<JTask> jList = await _context.JTasks.Where(e => e.Executor == null && e.IsComplete == false && e.IsGroup == false).ToListAsync();
            List<MTask> tasksAnotherList = new List<MTask>();

            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff };
                tasksAnotherList.Add(task);
            }

            tasksAnotherList = tasksAnotherList
                          .OrderBy(x =>
                          {
                              switch (x.Priority)
                              {
                                  case "Red": return 1;
                                  case "Yellow": return 2;
                                  case "Green": return 3;
                                  default: return 4;
                              }
                          })
                          .ToList();

            return tasksAnotherList;
        }

        // GET: Task/GetGroupList
        [HttpGet]
        [Route("task/GetGroupList")]
        public async Task<List<MGroupTask>> GetGroupList()
        {

            List<JTask> jList = await _context.JTasks.Where(e => e.IsGroup == true && e.IsComplete == false).ToListAsync();
            List<MTask>? mList = new List<MTask>();
            List<MGroupTask> gMList = new List<MGroupTask>();

            // составляем list заданий
            for (int i = 0; i < jList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
                var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
                mList.Add(task);
            }

            // сортируем list заданий
            mList = mList
                          .OrderBy(x =>
                          {
                              // Определяем приоритет в зависимости от значения поля Priority
                              switch (x.Priority)
                              {
                                  case "Red": return 1;
                                  case "Yellow": return 2;
                                  case "Green": return 3;
                                  default: return 4; // По умолчанию, если значение Priority не соответствует ожидаемым
                              }
                          })
                          .ToList();

            // составляем list групповых заданий
            var tasks = await _context.DGroupTasks.ToListAsync();

            // заполняем list групповых заданий
            for (int i = 0; i < tasks.Count; i++)
            {
                var childsList = mList.Where(x => x.GroupId == tasks[i].Id).ToList();
                if (childsList.Count == 0) continue;

                var mGTask = new MGroupTask { Name = tasks[i].Name, Description = tasks[i].Description, Code = tasks[i].Code, Created = tasks[i].Created, Tasks = childsList };
                gMList.Add(mGTask);
            }

            return gMList;
        }

        //// GET: Task/GetCreatorGroupList
        //[HttpGet]
        //[Route("task/GetCreatorGroupList/{userId}")]
        //public async Task<List<MGroupTask>> GetCreatorGroupList(int userId)
        //{

        //    List<JTask> jList = await _context.JTasks.Where(e => e.IsGroup == true && e.IsComplete == false).ToListAsync();
        //    List<MTask>? mList = new List<MTask>();
        //    List<MGroupTask> gCreatorMList = new List<MGroupTask>();

        //    // составляем list заданий
        //    for (int i = 0; i < jList.Count; i++)
        //    {
        //        DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
        //        var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
        //        mList.Add(task);
        //    }

        //    // сортируем list заданий
        //    mList = mList
        //                  .OrderBy(x =>
        //                  {
        //                      // Определяем приоритет в зависимости от значения поля Priority
        //                      switch (x.Priority)
        //                      {
        //                          case "Red": return 1;
        //                          case "Yellow": return 2;
        //                          case "Green": return 3;
        //                          default: return 4; // По умолчанию, если значение Priority не соответствует ожидаемым
        //                      }
        //                  })
        //                  .ToList();

        //    // составляем list групповых заданий
        //    var tasks = await _context.DGroupTasks.Where(x => x.Creator == userId).ToListAsync();

        //    // заполняем list групповых заданий
        //    for (int i = 0; i < tasks.Count; i++)
        //    {
        //        var childsList = mList.Where(x => x.GroupId == tasks[i].Id).ToList();
        //        if (childsList == null) continue;

        //        var mGTask = new MGroupTask { Name = tasks[i].Name, Description = tasks[i].Description, Code = tasks[i].Code, Created = tasks[i].Created, Tasks = childsList };
        //        gCreatorMList.Add(mGTask);
        //    }

        //    return gCreatorMList;
        //}

        //// GET: Task/GetAnotherGroupList
        //[HttpGet]
        //[Route("task/GetAnotherGroupList/{userId}")]
        //public async Task<List<MGroupTask>> GetAnotherGroupList(int userId)
        //{

        //    List<JTask> jList = await _context.JTasks.Where(e => e.IsGroup == true && e.IsComplete == false).ToListAsync();
        //    List<MTask>? mList = new List<MTask>();
        //    List<MGroupTask> gAnotherMList = new List<MGroupTask>();

        //    // составляем list заданий
        //    for (int i = 0; i < jList.Count; i++)
        //    {
        //        DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jList[i].Task);
        //        var task = new MTask { Id = jList[i].Id, IsActive = jList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jList[i].Description, Executor = jList[i].Executor, IsGroup = jList[i].IsGroup, GroupId = jList[i].GroupId, Priority = jList[i].Emergency, Created = jList[i].Dateon, PlanTimeToFinish = jList[i].Dateoff, };
        //        mList.Add(task);
        //    }

        //    // сортируем list заданий
        //    mList = mList
        //                  .OrderBy(x =>
        //                  {
        //                      // Определяем приоритет в зависимости от значения поля Priority
        //                      switch (x.Priority)
        //                      {
        //                          case "Red": return 1;
        //                          case "Yellow": return 2;
        //                          case "Green": return 3;
        //                          default: return 4; // По умолчанию, если значение Priority не соответствует ожидаемым
        //                      }
        //                  })
        //                  .ToList();

        //    // составляем list групповых заданий
        //    var tasks = await _context.DGroupTasks.Where(x => x.Creator != userId).ToListAsync();

        //    // заполняем list групповых заданий
        //    for (int i = 0; i < tasks.Count; i++)
        //    {
        //        var childsList = mList.Where(x => x.GroupId == tasks[i].Id).ToList();
        //        if (childsList == null) continue;

        //        var mGTask = new MGroupTask { Name = tasks[i].Name, Description = tasks[i].Description, Code = tasks[i].Code, Created = tasks[i].Created, Tasks = childsList };
        //        gAnotherMList.Add(mGTask);
        //    }

        //    return gAnotherMList;
        //}

        // GET: Task/getChilds
        [HttpGet]
        [Route("task/getChilds/{groupId}")]
        public async Task<List<MTask>> GetChilds(int groupId)
        {
            var childsList = await _context.JTasks.Where(x => x.GroupId == groupId && x.IsComplete == false).ToListAsync();
            List<MTask> list = new List<MTask>();

            for (int i = 0; i < childsList.Count; i++)
            {
                DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == childsList[i].Task);
                var task = new MTask { Id = childsList[i].Id, IsActive = childsList[i].IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = childsList[i].Description, Executor = childsList[i].Executor, IsGroup = childsList[i].IsGroup, GroupId = childsList[i].GroupId, Priority = childsList[i].Emergency, Created = childsList[i].Dateon, PlanTimeToFinish = childsList[i].Dateoff };
                list.Add(task);
            }

            list = list
                          .OrderBy(x =>
                          {
                              switch (x.Priority)
                              {
                                  case "Red": return 1;
                                  case "Yellow": return 2;
                                  case "Green": return 3;
                                  default: return 4;
                              }
                          })
                          .ToList();
            return list;
        }

        // GET: Task/getActiveTaskByUserId
        [HttpGet]
        [Route("task/getActiveTaskByUserId/{userId}")]
        public async Task<MTask> GetActiveTaskByUserId(int userId)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Executor == userId && x.IsComplete == false && x.IsActive == true);

            if (jTask == null)
            {
                return null;
            }

            DTask dTask = await _context.DTasks.FirstOrDefaultAsync(e => e.Id == jTask.Task);
            var task = new MTask { Id = jTask.Id, IsActive = jTask.IsActive, ParentId = dTask.Id, Name = dTask.Name, Description = jTask.Description, Executor = jTask.Executor, IsGroup = jTask.IsGroup, GroupId = jTask.GroupId, Priority = jTask.Emergency, Created = jTask.Dateon, PlanTimeToFinish = jTask.Dateoff };
            return task;
        }

        // GET: Task/checkExecutorActive
        [HttpGet]
        [Route("task/checkExecutorActive/{userId}")]
        public async Task<IActionResult> CheckExecutorActive(int userId)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Executor == userId && x.IsComplete == false && x.IsActive == true);
            
            if(jTask == null)
            { 
                return Ok();
            }
            return BadRequest();
        }

        // PUT: Task/changeActive
        [HttpPut]
        [Route("task/changeActive/{taskId}")]
        public async Task<IActionResult> ChangeActive(int taskId, bool active)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Id == taskId && x.IsComplete == false && x.IsActive == false);

            if (jTask == null)
            {
                return BadRequest();
            }

            jTask.IsActive = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: Task/changeExecutor
        [HttpPut]
        [Route("task/changeExecutor/{taskId}/{newExId}")]
        public async Task<IActionResult> ChangeExecutor(int taskId, int newExId)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Id == taskId && x.IsComplete == false);

            if (jTask == null)
            {
                return BadRequest();
            }

            jTask.Executor = newExId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: Task/changeComplete
        [HttpPut]
        [Route("task/changeComplete/{taskId}")]
        public async Task<IActionResult> ChangeComplete(int taskId, bool complete)
        {
            var jTask = await _context.JTasks.FirstOrDefaultAsync(x => x.Id == taskId && x.IsComplete == false && x.IsActive == true);

            if (jTask == null)
            {
                return BadRequest();
            }

            jTask.IsActive = false;
            jTask.IsComplete = true;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}