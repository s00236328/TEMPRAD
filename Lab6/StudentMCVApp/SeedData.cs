using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using System;
using System.Linq;

namespace StudentMCVApp
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CollegeDb(serviceProvider.GetRequiredService<DbContextOptions<CollegeDb>>()))
            {
                if (context == null || context.CoursesMCV == null)
                {
                    throw new ArgumentNullException("Null Context");
                }

                if (!context.CoursesMCV.Any())
                {
                    Console.WriteLine("no modules, creating seed data");

                    context.Database.EnsureCreated();

                    var module1 = new Module
                    {
                        Name = "Compsci",
                        Department = "Wizardry",
                        Lecturer = "Dr. Joe"
                    };

                    var module2 = new Module
                    {
                        Name = "Mathematics",
                        Department = "Mathematics",
                        Lecturer = "Dr. Skibidi"
                    };

                    context.CoursesMCV.AddRange(module1, module2);
                    context.SaveChanges();

                    var student1 = new Student
                    {
                        Name = "John Doe",
                        Age = 20,
                        EmailAddress = "john.doe@example.com"
                    };

                    var student2 = new Student
                    {
                        Name = "Jane Doe",
                        Age = 22,
                        EmailAddress = "jane.doe@example.com"
                    };

                    context.StudentsMCV.AddRange(student1, student2);
                    context.SaveChanges();

                    // Establish many-to-many relationships
                    student1.Courses.Add(module1);
                    student1.Courses.Add(module2);
                    student2.Courses.Add(module1);

                    context.SaveChanges();

                    Console.WriteLine("Seed data created");
                }
            }
        }
    }
}