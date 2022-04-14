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
         

            try
            {
                var user = await _userManager.FindByEmailAsync(modelData.Email);
                if (user != null)
                {
                    var result = await _signIn.PasswordSignInAsync(user.UserName, modelData.Password, modelData.RememberMe, false);
                    if (!result.Succeeded)
                    {

                        ModelState.AddModelError("UserLoginFormModel", "Incorrect password!");
                        return View(modelData);
                    }
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("UserLoginFormModel", "Incorrect e-mail");
                return View(modelData);
            }
            catch (Exception ex)
            {
                return View(modelData);
            }

            

            
        }



        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterFormModel modelData)
        {
            if (ModelState.IsValid)
            {
                var isUniqueEmail = !_userManager.Users.Any(u => u.Email == modelData.Email);
                var isUniqueUsername = !_userManager.Users.Any(u => u.UserName == modelData.UserName);
                if (isUniqueEmail)
                {
                    if (isUniqueUsername)
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
                    else
                    {
                        ModelState.AddModelError("Custom error", "This Username is already taken!");
                        return View(modelData);
                    }


                }
                else
                {
                    ModelState.AddModelError("Custom error", "This email is already linked to an account!");
                    return View(modelData);
                }


            }
            else
            {
                return View(modelData);
            }
           
        }


       
    }
}
