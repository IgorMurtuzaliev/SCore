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
       Task<IdentityResult> Create(RegisterViewModel registerViewModel);
       Task<SignInResult> LogIn(LoginViewModel loginViewModel);
    }
}
