using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private TaskService taskService; 
        public TaskController(TaskService service)
        {
            taskService = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<DailyTask>> getAll()
        {
            return await taskService.getTasks();
        }

        [HttpGet("[action]/{id?}")]
        public async Task<DailyTask> getOne(int? id)
        {
            return await taskService.getTask(id);
        }

        [HttpPost("[action]")]
        public async Task<DailyTask> createTask([FromBody] DailyTask task)
        {
            return await taskService.addTask(task);
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<DailyTask> removeOne(int? id)
        {
            return await taskService.removeTask(id);
        }

        [HttpPut("[action]")]
        public async Task<DailyTask> updateOne([FromBody] DailyTask task)
        {
            return await taskService.updateTask(task);
        }
    }
}
