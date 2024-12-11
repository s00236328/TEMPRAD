using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelsClass;
using PetASP;

namespace PetASP.Pages.OwnerP
{
    public class CreateModel : PageModel
    {
        private readonly PetASP.PetVetDb _context;

        public CreateModel(PetASP.PetVetDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VeterinarianId"] = new SelectList(_context.Veterinarians, "VeterinarianId", "Name");
            return Page();
        }

        [BindProperty]
        public Owner Owner { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Owners.Add(Owner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
