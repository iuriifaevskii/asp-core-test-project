﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class DailyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<DailyTaskTag> DailyTaskTags { get; set; }

        public DailyTask()
        {
            DailyTaskTags = new List<DailyTaskTag>();
        }
    }
}
