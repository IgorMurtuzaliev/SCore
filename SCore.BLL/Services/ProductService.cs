using SCore.BLL.Interfaces;
using SCore.DAL.Interfaces;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork db { get; set; }

        public ProductService(IUnitOfWork _db)
        {
            db = _db;
        }

        public void Create(Product product)
        {
            db.Products.Create(product);
            db.Products.Save();
        }

        public Product Get(int id)
        {
            return db.Products.Get(id);
        }

        public void Delete(int id)
        {
            db.Products.Delete(id);
            db.Products.Save();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.GetAll();
        }

        public void Edit(Product product)
        {
            db.Products.Edit(product);
            db.Products.Save();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose(disposing);
        }
    }
}
