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
    public class DetailsModel : PageModel
    {
        private readonly S00236328_classlibrary.FlightContext _context;

        public DetailsModel(S00236328_classlibrary.FlightContext context)
        {
            _context = context;
        }

        public Flight Flight { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            else
            {
                Flight = flight;
            }
            return Page();
        }
    }
}
