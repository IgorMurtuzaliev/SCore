using SCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Interfaces
{
    public interface IAccountService
    {
        void Register(RegisterViewModel registerViewModel);
    }
}
