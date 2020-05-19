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

        public DbSet<TestApplicationDatabase.Models.Person> Person { get; set; }

        public DbSet<TestApplicationDatabase.Models.Question> Question { get; set; }

        public DbSet<TestApplicationDatabase.Models.Student> Student { get; set; }

        public DbSet<TestApplicationDatabase.Models.Teacher> Teacher { get; set; }

        public DbSet<TestApplicationDatabase.Models.Test> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.QuestionTest>().HasKey(qt => new { qt.QuestionId, qt.TestId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.StudentTest>().HasKey(st => new { st.StudentId, st.TestId });
        }

        public DbSet<TestApplicationDatabase.Models.StudentTest> StudentTest { get; set; }

        public DbSet<TestApplicationDatabase.Models.QuestionTest> QuestionTest { get; set; }

    }
}
