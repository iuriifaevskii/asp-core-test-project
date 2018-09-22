using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DailyTaskTag> DailyTaskTags { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User { Id=1, Login="tom@gmail.com", Password="123" },
                new User { Id=2, Login="alice@gmail.com", Password="456" },
                new User { Id=3, Login="sam@gmail.com", Password="789" }
            });
            modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile[]
            {
                new UserProfile { Id=1, Name="tom", Age=19, PhoneNumber="+3809513123", UserId=1 },
                new UserProfile { Id=2, Name="alice", Age=19, PhoneNumber="+3809413124", UserId=2 },
                new UserProfile { Id=3, Name="sam", Age=20, PhoneNumber="+3809713121", UserId=3 }
            });
            modelBuilder.Entity<Role>().HasData(
            new Role[]
            {
                new Role { Id=1, Name="user" },
                new Role { Id=2, Name="admin" },
            });
            modelBuilder.Entity<UserRole>().HasData(
            new UserRole[]
            {
                new UserRole { Id=1, RoleId=1, UserId=1 },
                new UserRole { Id=2, RoleId=2, UserId=1 },
                new UserRole { Id=3, RoleId=1, UserId=2 },
                new UserRole { Id=4, RoleId=1, UserId=3 },
            });
            modelBuilder.Entity<DailyTaskTag>().HasData(
            new DailyTaskTag[]
            {
                new DailyTaskTag { Id=1, DailyTaskId=1, TagId=1 },
                new DailyTaskTag { Id=2, DailyTaskId=2, TagId=1 },
                new DailyTaskTag { Id=3, DailyTaskId=2, TagId=2 },
                new DailyTaskTag { Id=4, DailyTaskId=3, TagId=1 },
                new DailyTaskTag { Id=5, DailyTaskId=3, TagId=3 },
                new DailyTaskTag { Id=6, DailyTaskId=3, TagId=4 },
            });

            modelBuilder.Entity<DailyTask>().HasData(
            new DailyTask[]
            {
                new DailyTask { Id=1, Name = "Task 1", Description = "Description task 1" },
                new DailyTask { Id=2, Name = "Task 2", Description = "Description task 2" },
                new DailyTask { Id=3, Name = "Task 3", Description = "Description task 3" }
            });
            modelBuilder.Entity<Tag>().HasData(
            new Tag[]
            {
                new Tag { Id=1, Name="good day" },
                new Tag { Id=2, Name="very good" },
                new Tag { Id=3, Name="food" },
                new Tag { Id=4, Name="people" },
            });
            modelBuilder.Entity<Comment>().HasData(
            new Comment[]
            {
                new Comment { Id=1, Text="comment 1", Author="tom", AuthorId=1, DailyTaskId = 1 },
                new Comment { Id=2, Text="comment 2", Author="tom", AuthorId=1, DailyTaskId = 1 },
                new Comment { Id=3, Text="comment 3", Author="alice", AuthorId=2, DailyTaskId = 2 },
                new Comment { Id=4, Text="comment 4", Author="sam", AuthorId=3, DailyTaskId = 2 },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
