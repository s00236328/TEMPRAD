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
    public class DeleteModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextCat _context;

        public DeleteModel(Lab4Part3.Data.Lab4Part3ContextCat context)
        {
            _context = context;
        }

        [BindProperty]
        public MCategory MCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mcategory = await _context.MCategory.FirstOrDefaultAsync(m => m.ID == id);

            if (mcategory == null)
            {
                return NotFound();
            }
            else
            {
                MCategory = mcategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mcategory = await _context.MCategory.FindAsync(id);
            if (mcategory != null)
            {
                MCategory = mcategory;
                _context.MCategory.Remove(MCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
