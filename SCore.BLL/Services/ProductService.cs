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
            //save
        }

        public Product Get(int id)
        {
            return db.Products.Get(id);
        }
    }
}
