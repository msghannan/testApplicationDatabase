using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApplicationDatabase.Models;

namespace TestApplicationDatabase.Data
{
    public class TestApplicationDatabaseContext : DbContext
    {
        public TestApplicationDatabaseContext (DbContextOptions<TestApplicationDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TestApplicationDatabase.Models.AccountLogin> AccountLogin { get; set; }

        public DbSet<TestApplicationDatabase.Models.Person> Person { get; set; }

        public DbSet<TestApplicationDatabase.Models.Test> Test { get; set; }

        public DbSet<TestApplicationDatabase.Models.Question> Question { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.PersonTest>().HasKey(pt => new { pt.PersonId, pt.TestId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.QuestionTest>().HasKey(qt => new { qt.QuestionId, qt.TestId });
        }

        public DbSet<TestApplicationDatabase.Models.PersonTest> PersonTest { get; set; }

        public DbSet<TestApplicationDatabase.Models.QuestionTest> QuestionTest { get; set; }

        public DbSet<TestApplicationDatabase.Models.Student> Student { get; set; }

        public DbSet<TestApplicationDatabase.Models.Teacher> Teacher { get; set; }
    }
}
