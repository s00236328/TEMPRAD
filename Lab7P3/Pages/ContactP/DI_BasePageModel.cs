using Lab7P3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab7P3.Pages.ContactP
{
    public class DI_BasePageModel : PageModel
    {
        protected ApplicationDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public DI_BasePageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {

            Console.WriteLine("=============================================================================================================================");
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;

            Console.WriteLine("=============================================================================================================================");
        }
    }
}
