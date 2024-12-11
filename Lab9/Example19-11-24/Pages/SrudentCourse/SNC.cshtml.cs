using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Example19_11_24.Pages.SrudentCourse
{
    public class SNCModel : PageModel
    {
        private readonly Example19_11_24.Data.CollegeContext _context;

        public SNCModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.
                Include(s=>s.Courses).
                ToListAsync();
        }
        public async Task<ActionResult> OnPostUnenroll(int CID,int SID)
        {
            Console.WriteLine(SID);
            Console.WriteLine(CID);
            Console.WriteLine("TOUCHER");
            var student = _context.Students.Include(S => S.Courses).FirstOrDefault(s => s.StudentId == SID);
            Console.WriteLine(student.FirstName);
            var course = _context.Courses.Include(C => C.Students).FirstOrDefault(C => C.CourseId == CID);
            Console.WriteLine(course.Name);
            student.Courses.Remove(course);
            course.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }

}
