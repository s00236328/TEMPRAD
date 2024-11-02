using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Data;
using ProductModel;

namespace Lab4Part3.Pages.Productsfolder
{
    public class DeleteModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextPRO _context;

        public DeleteModel(Lab4Part3.Data.Lab4Part3ContextPRO context)
        {
            _context = context;
        }

        [BindProperty]
        public MProduct MProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mproduct = await _context.MProduct.FirstOrDefaultAsync(m => m.ID == id);

            if (mproduct == null)
            {
                return NotFound();
            }
            else
            {
                MProduct = mproduct;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mproduct = await _context.MProduct.FindAsync(id);
            if (mproduct != null)
            {
                MProduct = mproduct;
                _context.MProduct.Remove(MProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
