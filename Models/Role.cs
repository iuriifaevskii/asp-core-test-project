﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public Role()
        {
            UserRoles = new List<UserRole>();
        }
    }
}
