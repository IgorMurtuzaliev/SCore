using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        void Save();
        void Dispose(bool disposing);
    }
}
