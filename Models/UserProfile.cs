using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
