using SCore.BLL.Interfaces;
using SCore.DAL.Interfaces;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork db { get; set; }
        public UserService(IUnitOfWork _db)
        {
            db = _db;
        }

        public void Create(User user)
        {
            db.Users.Create(user);
            db.Users.Save();
        }

        public User Get(int id)
        {
            return db.Users.Get(id);
        }

        public void Delete(int id)
        {
            db.Users.Delete(id);
            db.Users.Save();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.GetAll();
        }

        public void Edit(User user)
        {
            db.Users.Edit(user);
            db.Users.Save();
        }

        public User Get(string id)
        {
            return db.Users.Get(id);
        }

        public void Delete(string id)
        {
            db.Users.Delete(id);
            db.Users.Save();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose(disposing);
        }
    }
}
