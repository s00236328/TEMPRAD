using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentClassLibrary;

namespace StudentMCVApp
{
    public class CollegeDb : DbContext
    {
        public DbSet<Student> StudentsMCV { get; set; }
        public DbSet<Module> CoursesMCV { get; set; }
        public CollegeDb(DbContextOptions<CollegeDb> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=D:\\repo\\TEMPRAD\\Lab6\\CollegeMCV.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name).HasMaxLength(50);
            });
            modelBuilder.Entity<Student>()
           .HasMany(s => s.Courses)
           .WithMany(m => m.Students)
           .UsingEntity<Dictionary<string, object>>(
               "StudentModules",
               j => j.HasOne<Module>().WithMany().HasForeignKey("ModuleId"),
               j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"));
        }

    
    }
}