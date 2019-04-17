using SCore.Models;
using System.Collections.Generic;

namespace SCore.BLL.Interfaces
{
    public interface IOrderService
    {
        void Create(Order order);
        Order Get(int id);
        void Delete(int id);
        IEnumerable<Order> GetAll();
        void Edit(Order product);
        void Dispose();
    }
}
