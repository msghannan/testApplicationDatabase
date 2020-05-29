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

        public DbSet<TestApplicationDatabase.Models.Account> Account { get; set; }

        public DbSet<TestApplicationDatabase.Models.Person> Person { get; set; }

        public DbSet<TestApplicationDatabase.Models.Test> Test { get; set; }

        public DbSet<TestApplicationDatabase.Models.Question> Question { get; set; }

       
        public DbSet<TestApplicationDatabase.Models.PersonTest> PersonTest { get; set; }

       
        public DbSet<TestApplicationDatabase.Models.StudentsResults> StudentsResults { get; set; }
        public DbSet<TestApplicationDatabase.Models.Role> Role { get; internal set; }
        public DbSet<TestApplicationDatabase.Models.Answer> Answer { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to Many
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.PersonTest>().HasKey(pt => new { pt.PersonId, pt.TestId });

          
            // One to Many
            //modelBuilder.Entity<Question>()
            //    .HasRequired<Test>(s => s.CurrentGrade)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey<int>(s => s.TestId);

            //}
            //public class SchoolContext : DbContext
            //{
            //    public DbSet<Student> Students { get; set; }
            //    public DbSet<Grade> Grades { get; set; }

            //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //    {
            //        configures one-to - many relationship
            //        modelBuilder.Entity<Student>()
            //            .HasRequired<Grade>(s => s.CurrentGrade)
            //            .WithMany(g => g.Students)
            //            .HasForeignKey<int>(s => s.CurrentGradeId);
            //    }
            //}
        }
    }

}


       
    

