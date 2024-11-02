using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductModel;

namespace Lab4Part3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SupplierLab4Part3Context _context;

        public IndexModel(SupplierLab4Part3Context context)
        {
            _context = context;
        }

        public IList<MCategory> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
