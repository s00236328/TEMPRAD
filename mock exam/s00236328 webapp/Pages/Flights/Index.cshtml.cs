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
    public class IndexModel : PageModel
    {
        private readonly S00236328_classlibrary.FlightContext _context;

        public IndexModel(S00236328_classlibrary.FlightContext context)
        {
            _context = context;
        }

        public IList<Passenger> Passenger { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Passenger = await _context.Passengers.ToListAsync();
        }
    }
}
