using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetFoodOrder.Models;
namespace ProjetFoodOrder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel login)
        {   if (ModelState.IsValid)
            {
                
                var result =await  _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Invalid LogIn Attempt");
            }
            return View(login);
        }

        public async Task <IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Name = register.Name,
                    Address = register.Address,
                    Email = register.Email,
                    UserName = register.Email
                };

                // Attendez que la tâche se termine en utilisant 'await'
                var result = await _userManager.CreateAsync(user, register.password);

                if (result.Succeeded)
                {
                    // Connectez l'utilisateur après la création du compte
                    await _signInManager.PasswordSignInAsync(user, register.password, false, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Gérez les erreurs
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(register);
        }


    }
}

