using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab7P3.Data;
using Lab7P3.Models;

namespace Lab7P3.Pages.ContactP
{
    public class IndexModel : PageModel
    {
        private readonly Lab7P3.Data.ApplicationDbContext _context;

        public IndexModel(Lab7P3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact.ToListAsync();
        }
    }
}
