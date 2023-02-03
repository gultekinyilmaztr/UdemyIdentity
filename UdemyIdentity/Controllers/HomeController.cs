using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Formatting;
using System.Threading.Tasks;
using UdemyIdentity.Models;
using UdemyIdentity.Models.ViewModels;

namespace UdemyIdentity.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> userManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userlogin)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(userlogin.Email);

                if (user != null)
                {
                    await SignInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await SignInManager.PasswordSignInAsync(user, userlogin.Password,userlogin.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (TempData["ReturnUrl"]!=null)
                        {
                            return RedirectToAction(TempData["ReturnUrl"].ToString());
                        }
                        return RedirectToAction("Index", "Member");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Geçersiz email adresi veya şifresi");

                }
            }
            return View(userlogin);
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userViewModel);
        }
    }
}
