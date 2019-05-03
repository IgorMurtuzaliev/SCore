using SCore.Models;

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
