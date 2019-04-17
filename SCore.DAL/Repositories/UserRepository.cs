using Microsoft.EntityFrameworkCore;
using SCore.DAL.EF;
using SCore.DAL.Interfaces;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCore.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext db;
        public UserRepository(ApplicationDbContext context)
        {
            this.db = context;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
