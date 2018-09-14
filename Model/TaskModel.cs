using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class TaskModel
    {
        public TaskModel(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public int id;
        public string name;
        public string description;
    }
}
