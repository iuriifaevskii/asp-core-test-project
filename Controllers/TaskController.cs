using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private Context db; 
        public TaskController(Context context)
        {
            db = context;
        }

        [HttpGet("[action]")]
        public async Task<List<DailyTask>> getAll()
        {
            return await db.DailyTasks.ToListAsync();
        }

        [HttpGet("[action]/{id?}")]
        public async Task<DailyTask> getOne(int? id)
        {
            return await db.DailyTasks.FirstOrDefaultAsync(item => item.Id == id);
        }

        [HttpPost("[action]")]
        public async Task<DailyTask> createTask([FromBody] DailyTask task)
        {
            if (task == null)
            {
                return null;
            }
            db.DailyTasks.Add(task);
            await db.SaveChangesAsync();
            return task;
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<DailyTask> removeOne(int? id)
        {
            DailyTask task = db.DailyTasks.SingleOrDefault(item => item.Id == id);
            if (task == null)
            {
                return null;
            }
            db.DailyTasks.Remove(task);
            await db.SaveChangesAsync();
            return task;
        }
    }
}
