using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateDemoApp.Components
{
    public class NavbarViewComponent:ViewComponent
    {
       private SignInManager<IdentityUser> SignInManager { get; set; }
        private UserManager<IdentityUser> UserManager { get; set; }
        public NavbarViewComponent(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.SignInManager = signInManager;
            this.UserManager = userManager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            return View();


        }

       
       
    }
}
