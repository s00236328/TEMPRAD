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
        public DbSet<Course> CoursesMCV { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=D:\\repo\\TEMPRAD\\Lab6\\CollegeMCV.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key

                entity.Property(e => e.Name)
                      .IsRequired()          // Name is required
                      .HasMaxLength(50);     // Max length for Name is 50

                entity.Property(e => e.EmailAddress)
                      .IsRequired()          // Email is required
                      .HasMaxLength(100);    // Max length for EmailAddress is 100

                entity.Property(e => e.Age)
                      .IsRequired();         // Age is required

                entity.HasMany(e => e.Courses) // Relationship with Course
                      .WithMany(e => e.Students); // Many-to-many relationship
                //seed data
                entity.HasData(
           new Student { Id = 1, Name = "Blood Johnson", Age = 20, EmailAddress = "alice@gmail.com" },
           new Student { Id = 2, Name = "Crip Smith", Age = 22, EmailAddress = "bob@gmail.com" }
       );
            });

            // Configure Course entity
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id); // Primary key

                entity.Property(e => e.Name)
                      .IsRequired()          // Name is required
                      .HasMaxLength(100);    // Max length for Name is 100

                entity.Property(e => e.Department)
                      .IsRequired()          // Department is required
                      .HasMaxLength(50);     // Max length for Department is 50

                entity.Property(e => e.Lecturer)
                      .IsRequired()          // Lecturer is required
                      .HasMaxLength(50);     // Max length for Lecturer is 50

                entity.HasMany(e => e.Students) // Relationship with Student
                      .WithMany(e => e.Courses); // Many-to-many relationship
                //seed data
                entity.HasData(
          new Course { Id = 1, Name = "Mathematics", Department = "Mathematics", Lecturer = "Dr. Skibidi" },
          new Course { Id = 2, Name = "Physics", Department = "Physics", Lecturer = "Dr. Pimp" }
      );
            });
            modelBuilder.Entity<Student>()
       .HasMany(s => s.Courses)
       .WithMany(c => c.Students)
       .UsingEntity<Dictionary<string, object>>(
           "StudentCourse",
           sc => sc.HasData(
               new { StudentsId = 1, CoursesId = 1 }, // Alice is enrolled in Mathematics 101
               new { StudentsId = 2, CoursesId = 2 }  // Bob is enrolled in Physics 101
           )
       );
        }
    }
}