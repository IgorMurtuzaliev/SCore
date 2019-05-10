using SCore.Models;
using SCore.Models.Models;
using System.Collections.Generic;

namespace SCore.BLL.Interfaces
{
    public interface IProductService
    {
        void Create(ProductViewModel model);
        Product Get(int id);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        void Edit(Product product);
        void Dispose(bool disposing);
    }
}
