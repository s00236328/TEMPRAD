﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;

namespace Example19_11_24.Pages.StudentNoCourse
{
    public class BrokiesModel : PageModel
    {
        private readonly Example19_11_24.Data.CollegeContext _context;

        public BrokiesModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //get students with 0 or less then 0 courses
            Student = await _context.Students.
                Where(s=>s.Courses.Count <= 0).
                ToListAsync();
        }
    }
}
