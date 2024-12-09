using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using StudentMCVApp;

namespace StudentMCVApp.Pages.CoursePage
{
    public class DetailsModel : PageModel
    {
        private readonly StudentMCVApp.CollegeDb _context;

        public DetailsModel(StudentMCVApp.CollegeDb context)
        {
            _context = context;
        }

        public Module Module { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.CoursesMCV.Include(c=>c.Students).FirstOrDefaultAsync(m => m.Id == id);
            if (module == null)
            {
                return NotFound();
            }
            else
            {
                Module = module;
            }
            return Page();
        }
    }
}
