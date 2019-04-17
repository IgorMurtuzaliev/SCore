using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
