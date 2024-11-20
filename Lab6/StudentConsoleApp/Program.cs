using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using System;
using System.Collections.Generic;

namespace StudentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the DbContext
            using (var dbContext = new CollegeDb())
            {
                // Ensure the database is created
                dbContext.Database.EnsureCreated();

                // Create new Courses
                var course1 = new Module
                {
                    Name = "Mathematics 101",
                    Department = "Mathematics",
                    Lecturer = "Dr. Smith"
                };

                var course2 = new Module
                {
                    Name = "Computer Science 101",
                    Department = "Computer Science",
                    Lecturer = "Prof. Johnson"
                };

                // Create a new Student and assign courses to the student
                var student = new Student
                {
                    Name = "John Doe",
                    Age = 20,
                    EmailAddress = "johndoe@example.com",
                    Courses = new List<Module> { course1, course2 } // Assign courses
                };

                // Add the courses and student to the DbContext
                dbContext.Courses.Add(course1);
                dbContext.Courses.Add(course2);
                dbContext.Students.Add(student);

                // Save changes to the database
                dbContext.SaveChanges();
                Console.WriteLine("Student and courses added to the database.");
            }
        }
    }
}