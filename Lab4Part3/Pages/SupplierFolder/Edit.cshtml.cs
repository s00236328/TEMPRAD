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

namespace Lab4Part3.Pages.SupplierFolder
{
    public class EditModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextSUP _context;

        public EditModel(Lab4Part3.Data.Lab4Part3ContextSUP context)
        {
            _context = context;
        }

        [BindProperty]
        public MSupplier MSupplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msupplier =  await _context.MSupplier.FirstOrDefaultAsync(m => m.ID == id);
            if (msupplier == null)
            {
                return NotFound();
            }
            MSupplier = msupplier;
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

            _context.Attach(MSupplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MSupplierExists(MSupplier.ID))
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

        private bool MSupplierExists(int id)
        {
            return _context.MSupplier.Any(e => e.ID == id);
        }
    }
}
