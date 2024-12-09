using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using StudentMCVApp;

namespace StudentMCVApp.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly StudentMCVApp.CollegeDb _context;

        public IndexModel(StudentMCVApp.CollegeDb context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.StudentsMCV.ToListAsync();
        }
    }
}
