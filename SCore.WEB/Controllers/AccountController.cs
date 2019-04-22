using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Services;
using SCore.Models.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SCore.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        

        public AccountController(IAccountService _service)
        {
            service = _service;
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
        public async Task< ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await service.Create(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                    
                }
            }
            return View(model);
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
    }
}