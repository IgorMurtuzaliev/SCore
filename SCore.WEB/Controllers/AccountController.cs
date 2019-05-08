using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.Models;
using SCore.Models.Models;

namespace SCore.WEB.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountService service;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> _userManager, IAccountService _service, SignInManager<User> _signInManager, IUserService _userService)
        {
            service = _service;
            userManager = _userManager;
            signInManager = _signInManager;
            userService = _userService;
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
        public IActionResult SignInWithGoogle()
        {
            var authenticationProperties = signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "Google");
        }
        public IActionResult SignInWithFacebook()
        {
            var authenticationProperties = signInManager.ConfigureExternalAuthenticationProperties("Facebook", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "Facebook");
        }
        public async Task<IActionResult> HandleExternalLogin()
        {
            var info = await signInManager.GetExternalLoginInfoAsync();

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (!result.Succeeded) //user does not exist yet
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var newUser = new User
                {
                    Name = email,
                    LastName = email,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                var createResult = await userManager.CreateAsync(newUser);
                await userManager.AddToRoleAsync(newUser, "User");
                if (!createResult.Succeeded)
                    throw new Exception(createResult.Errors.Select(e => e.Description).Aggregate((errors, error) => $"{errors}, {error}"));

                await userManager.AddLoginAsync(newUser, info);
                var newUserClaims = info.Principal.Claims.Append(new Claim("userId", newUser.Id));
                await userManager.AddClaimsAsync(newUser, newUserClaims);
                await signInManager.SignInAsync(newUser, isPersistent: false);
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetUsersAccount(string id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            User user = userService.Get(id);
            return View(user);
        }
        
    }
}