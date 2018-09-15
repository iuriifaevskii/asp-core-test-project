using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private static TaskModel[] tasks = new TaskModel[]
        {
            new TaskModel(1, "make review", "simple description 1"),
            new TaskModel(2, "clean a room", "simple description 2"),
            new TaskModel(3, "build a house", "simple description 3")
        };

        [HttpGet("[action]")]
        public IEnumerable<TaskModel> getAll()
        {
            return tasks;
        }

        [HttpGet("[action]/{id?}")]
        public TaskModel getOne(int? id)
        {
            return tasks.FirstOrDefault(item => item.id == id);
        }
    }
}
