﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab7P3.Data;
using Lab7P3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Lab7P3.Authorization;

namespace Lab7P3.Pages.ContactP
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly Lab7P3.Data.ApplicationDbContext _context;

        public DeleteModel(
           ApplicationDbContext context,
           IAuthorizationService authorizationService,
           UserManager<IdentityUser> userManager)
           : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact? _contact = await Context.Contact.FirstOrDefaultAsync(
                                                 m => m.ContactId == id);

            if (_contact == null)
            {
                return NotFound();
            }
            Contact = _contact;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Contact,
                                                     ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var contact = await Context
                .Contact.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, contact,
                                                     ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Contact.Remove(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
