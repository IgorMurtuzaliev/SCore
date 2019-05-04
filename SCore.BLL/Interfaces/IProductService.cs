using SCore.Models;
using System.Collections.Generic;

namespace SCore.BLL.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        Product Get(int id);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        void Edit(Product product);
        void Dispose(bool disposing);
    }
}
