using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S00236328_classlibrary;

namespace s00236328_webapp.Pages.Flights
{
    public class CreateModel : PageModel
    {
        private readonly S00236328_classlibrary.FlightContext _context;

        public CreateModel(S00236328_classlibrary.FlightContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Passenger Passenger { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Passengers.Add(Passenger);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
