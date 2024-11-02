using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab4Part3.Data;
using ProductModel;

namespace Lab4Part3.Pages.CategoriesFolder
{
    public class CreateModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextCat _context;

        public CreateModel(Lab4Part3.Data.Lab4Part3ContextCat context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MCategory MCategory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MCategory.Add(MCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
