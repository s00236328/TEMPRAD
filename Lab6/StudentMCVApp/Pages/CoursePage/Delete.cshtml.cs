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
    public class DeleteModel : PageModel
    {
        private readonly StudentMCVApp.CollegeDb _context;

        public DeleteModel(StudentMCVApp.CollegeDb context)
        {
            _context = context;
        }

        [BindProperty]
        public Module Module { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.CoursesMCV.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.CoursesMCV.FindAsync(id);
            if (module != null)
            {
                Module = module;
                _context.CoursesMCV.Remove(Module);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
