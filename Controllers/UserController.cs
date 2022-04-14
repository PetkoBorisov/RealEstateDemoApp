using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.User;

namespace RealEstateDemoApp.Controllers
{
    public class UserController : Controller
    {
        public SignInManager<IdentityUser> _signIn;
        public UserManager<IdentityUser> _userManager;
        public UserController(SignInManager<IdentityUser> signIn, UserManager<IdentityUser> userManager)
        {
            this._signIn = signIn;
            this._userManager = userManager;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginFromModel modelData)
        {
            var user = await _userManager.FindByEmailAsync(modelData.Email);
           var result = await _signIn.PasswordSignInAsync(user.UserName, modelData.Password,modelData.RememberMe,false);
           

            

            if (!result.Succeeded)
            {
                
                return View(modelData);
            }
            return RedirectToAction("Index","Home");
        }



        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterFormModel modelData)
        {
            var identityUser = new IdentityUser
            {
                UserName = modelData.UserName,
                Email = modelData.Email,
                PhoneNumber = modelData.PhoneNumber,


            };
            var result = await _userManager.CreateAsync(identityUser, modelData.Password);

            if (!result.Succeeded)
            {
                return View(modelData);
            }
            return RedirectToAction("Index", "Home");
        }


       
    }
}
