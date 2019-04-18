using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using SCore.BLL.Interfaces;
using SCore.Models;
using SCore.Models.Entities;
using SCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Create(RegisterViewModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Email,Name = model.Name, LastName = model.LastName};
            // добавляем пользователя
            await _userManager.CreateAsync(user, model.Password);

            //await _userManager.AddToRoleAsync(user, "User");
        }

        public async Task<SignInResult> LogIn(LoginViewModel model)
        {
           SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }
    }
    
}
