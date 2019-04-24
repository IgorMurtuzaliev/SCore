using Microsoft.AspNetCore.Identity;
using SCore.Models;
using SCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Interfaces
{
    public interface IAccountService
    {
       Task<IdentityResult> Create(RegisterViewModel registerViewModel, string url);
       Task<SignInResult> LogIn(LoginViewModel loginViewModel);
       Task Logout();
        Task<IdentityResult> ConfirmEmail(string userId, string code);
    }
}
