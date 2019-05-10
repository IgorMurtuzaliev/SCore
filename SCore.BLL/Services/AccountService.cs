﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SCore.BLL.Interfaces;
using SCore.Models;
using SCore.Models.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SCore.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        private readonly IFileManager _fileManager;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, IFileManager fileManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _fileManager = fileManager;
        }

        public async Task<IdentityResult> Create(RegisterViewModel model, string url)
        {
            User user = new User { Email = model.Email, UserName = model.Email,Name = model.Name, LastName = model.LastName };
            if (model.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                }
                // установка массива байтов
                user.Avatar = imageData;
            }
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encode = HttpUtility.UrlEncode(code);
                var callbackurl = new StringBuilder("https://").AppendFormat(url).AppendFormat("/Account/ConfirmEmail").AppendFormat($"?userId={user.Id}&code={encode}");
                await _emailSender.SendEmailAsync(user.Email, "Тема письма", $"Please confirm your account by <a href='{callbackurl}'>clicking here</a>.");
                await _signInManager.SignInAsync(user, false);
                await _userManager.AddToRoleAsync( user,"User");
            }
            return result;
        }

        

        public async Task<SignInResult> LogIn(LoginViewModel model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
            return result;

        }
        public async Task<IdentityResult> ConfirmEmail(string userId, string code)
        {
            User user = await _userManager.FindByIdAsync(userId);
            IdentityResult success = await _userManager.ConfirmEmailAsync(user, code);
            return success;
        }
        public Task Logout()
        {
           return _signInManager.SignOutAsync();
           
        }

    }
    
}
