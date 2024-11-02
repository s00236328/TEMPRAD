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

namespace Lab4Part3.Pages.Productsfolder
{
    public class EditModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextPRO _context;

        public EditModel(Lab4Part3.Data.Lab4Part3ContextPRO context)
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

            var mproduct =  await _context.MProduct.FirstOrDefaultAsync(m => m.ID == id);
            if (mproduct == null)
            {
                return NotFound();
            }
            MProduct = mproduct;
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

            _context.Attach(MProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MProductExists(MProduct.ID))
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

        private bool MProductExists(int id)
        {
            return _context.MProduct.Any(e => e.ID == id);
        }
    }
}
