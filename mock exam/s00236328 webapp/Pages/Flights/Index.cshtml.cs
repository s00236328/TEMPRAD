using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S00236328_classlibrary;

namespace s00236328_webapp.Pages.Flights_model
{
    public class IndexModel : PageModel
    {
        private readonly S00236328_classlibrary.FlightContext _context;

        public IndexModel(S00236328_classlibrary.FlightContext context)
        {
            _context = context;
        }

        public IList<Flight> Flight { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Flight = await _context.Flights.ToListAsync();
        }
    }
}
