﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }

        public int DailyTaskId { get; set; }
        public DailyTask DailyTask { get; set; }
    }
}
