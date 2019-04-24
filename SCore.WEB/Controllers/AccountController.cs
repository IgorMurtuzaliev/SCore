using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Services;
using SCore.Models;
using SCore.Models.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SCore.WEB.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountService service;
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> _userManager, IAccountService _service)
        {
            service = _service;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {

                IdentityResult result = await service.Create(model, HttpContext.Request.Host.ToString());
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                    
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }           
           IdentityResult result = await service.ConfirmEmail(userId, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await service.LogIn(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await service.Logout();
            return RedirectToAction("LogIn");
        }
    }
}