using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.User;

namespace RealEstateDemoApp.Controllers
{
    public class UserController : Controller
    {
        public SignInManager<IdentityUser> _signIn;
        public UserController(SignInManager<IdentityUser> signIn)
        {
            _signIn = signIn;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginFromModel modelData)
        {

            var result = await _signIn.PasswordSignInAsync(modelData.Email, modelData.Password,true,true);
            return RedirectToAction("Index","Home");
        }
    }
}
