using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Interfaces
{
    public interface IUserService
    {
        void Create(User product);
        IEnumerable<User> GetAll();
        void Edit(User product);
        User Get(string id);
        void Delete(string id);
        void Dispose(bool disposing);
    }
}
