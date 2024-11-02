using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Data;
using ProductModel;

namespace Lab4Part3.Pages.CategoriesFolder
{
    public class IndexModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextCat _context;

        public IndexModel(Lab4Part3.Data.Lab4Part3ContextCat context)
        {
            _context = context;
        }

        public IList<MCategory> MCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MCategory = await _context.MCategory.ToListAsync();
        }
    }
}
