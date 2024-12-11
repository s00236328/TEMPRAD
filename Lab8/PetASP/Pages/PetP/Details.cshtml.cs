﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly PetASP.PetVetDb _context;

        public DetailsModel(PetASP.PetVetDb context)
        {
            _context = context;
        }

        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }
            else
            {
                Pet = pet;
            }
            return Page();
        }
    }
}
