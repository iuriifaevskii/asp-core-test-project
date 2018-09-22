using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DailyTaskTag
    {
        public int Id { get; set; }

        public int DailyTaskId { get; set; }
        public DailyTask DailyTask { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
