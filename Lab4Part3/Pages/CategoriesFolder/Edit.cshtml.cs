using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Data;
using ProductModel;

namespace Lab4Part3.Pages.CategoriesFolder
{
    public class EditModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextCat _context;

        public EditModel(Lab4Part3.Data.Lab4Part3ContextCat context)
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

            var mcategory =  await _context.MCategory.FirstOrDefaultAsync(m => m.ID == id);
            if (mcategory == null)
            {
                return NotFound();
            }
            MCategory = mcategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MCategoryExists(MCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MCategoryExists(int id)
        {
            return _context.MCategory.Any(e => e.ID == id);
        }
    }
}
