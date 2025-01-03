using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S00236328_classlibrary;

namespace s00236328_webapp.Pages.Flights
{
    public class DeleteModel : PageModel
    {
        private readonly S00236328_classlibrary.FlightContext _context;

        public DeleteModel(S00236328_classlibrary.FlightContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Passenger Passenger { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FirstOrDefaultAsync(m => m.PassengerId == id);

            if (passenger == null)
            {
                return NotFound();
            }
            else
            {
                Passenger = passenger;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                Passenger = passenger;
                _context.Passengers.Remove(Passenger);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
