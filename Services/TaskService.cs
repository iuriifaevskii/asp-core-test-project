using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TaskService
    {
        private Context db;
        public TaskService(Context context)
        {
            db = context;
        }

        public void Initialize()
        {
            if (!db.DailyTasks.Any())
            {
                db.DailyTasks.AddRange(
                    new DailyTask { Name = "Task 1", Description = "Description task 1" },
                    new DailyTask { Name = "Task 2", Description = "Description task 2" },
                    new DailyTask { Name = "Task 3", Description = "Description task 3" }
                );
                db.SaveChanges();
            }
        }

        public async Task<IEnumerable<DailyTask>>getTasks()
        {
            return await db.DailyTasks.ToListAsync();
        }

        public async Task<DailyTask> getTask(int? id)
        {
            DailyTask task = null;
            if (id != null)
            {
                task = await db.DailyTasks.FirstOrDefaultAsync(item => item.Id == id);
            }
            return task;
        }

        public async Task<DailyTask> addTask(DailyTask task)
        {
            if (task == null)
            {
                return null;
            }
            await db.DailyTasks.AddAsync(task);
            await db.SaveChangesAsync();
            return task;
        }

        public async Task<DailyTask> removeTask(int? id)
        {
            if (id != null)
            {
                DailyTask task = await db.DailyTasks.SingleOrDefaultAsync(item => item.Id == id);
                if (task == null)
                {
                    return null;
                }
                db.DailyTasks.Remove(task);
                await db.SaveChangesAsync();
                return task;
            }
            return null;
        }

        public async Task<DailyTask> updateTask(DailyTask task)
        {
            DailyTask newTask = await db.DailyTasks.SingleOrDefaultAsync(item => item.Id == task.Id);
            if (newTask != null)
            {
                newTask.Name = task.Name;
                newTask.Description = task.Description;
                db.DailyTasks.Update(newTask);
            }
            
            await db.SaveChangesAsync();
            return newTask;
        }
    }
}
