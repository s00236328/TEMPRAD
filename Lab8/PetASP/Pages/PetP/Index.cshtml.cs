using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelsClass;
using PetASP;

namespace PetASP.Pages.PetP
{
    public class IndexModel : PageModel
    {
        private readonly PetASP.PetVetDb _context;

        public IndexModel(PetASP.PetVetDb context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pet = await _context.Pets
                .Include(p => p.Owner).ToListAsync();
        }
    }
}
