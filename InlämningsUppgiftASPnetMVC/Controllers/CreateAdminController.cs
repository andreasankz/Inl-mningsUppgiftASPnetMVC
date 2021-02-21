using InlämningsUppgiftASPnetMVC.Data;
using InlämningsUppgiftASPnetMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgiftASPnetMVC.Controllers
{

    public class CreateAdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateAdminController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_userManager.Users.Any())
                return View();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAdminViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@domain.com",
                    Email = "admin@domain.com",
                    FirstName = "Admin",
                    LastName = "Account"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                    await _roleManager.CreateAsync(new IdentityRole("Student"));

                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }
    }
}
