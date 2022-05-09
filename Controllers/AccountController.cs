using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MVCProject.Models;
using System.Threading.Tasks;
using MVCProject.Controllers;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signinManager;
        private UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signinManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(loginView.UserName, loginView.Password, loginView.RememberMe, false); //check

                if (result.Succeeded)
                {
                    if (loginView.UserName == "Admin") //if login user is admin go to index, if not go to create
                    {
                        return RedirectToAction("Index", "Reservation");
                    }
                    else
                    {
                        return RedirectToAction("Create", "Reservation");
                    }
                }
            }
            ModelState.AddModelError("", "failed to login");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User newuser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString(),
                    Email = registerViewModel.Email
                };
                var result = await _userManager.CreateAsync(newuser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    //21. after start.c=adduser
                    var addUser = await _userManager.FindByNameAsync(newuser.UserName);//if added user has username as admin then going to become admin
                    if (addUser.UserName == "Admin")                                       //big flaws in this
                    {
                        await _userManager.AddToRoleAsync(addUser, "Admin"); //this admin will also be normal employee, so 1 user can have multip roles
                        await _userManager.AddToRoleAsync(addUser, "Customer"); //bc admit is also a normal employee
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(addUser, "Customer");
                    }

                    return RedirectToAction("Login", "Account"); //once register go to login then enter login inf and get into system
                }
                foreach (var error in result.Errors)//if not succeed here and can show user the errors/why not succesfful
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
