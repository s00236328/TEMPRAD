using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Data;
using ProductModel;

namespace Lab4Part3.Pages.SupplierFolder
{
    public class DetailsModel : PageModel
    {
        private readonly Lab4Part3.Data.Lab4Part3ContextSUP _context;

        public DetailsModel(Lab4Part3.Data.Lab4Part3ContextSUP context)
        {
            _context = context;
        }

        public MSupplier MSupplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msupplier = await _context.MSupplier.FirstOrDefaultAsync(m => m.ID == id);
            if (msupplier == null)
            {
                return NotFound();
            }
            else
            {
                MSupplier = msupplier;
            }
            return Page();
        }
    }
}
