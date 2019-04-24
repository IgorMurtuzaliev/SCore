using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Models;
using SCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> Create(CreateRoleModel model);
        IEnumerable<ApplicationRole> GetAll();
        Task<IdentityResult> Edit(EditRoleModel model);
        Task Edit(string id);
        Task<IdentityResult> Delete(string id);
    }
}
