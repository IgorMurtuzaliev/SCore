using SCore.BLL.Interfaces;
using SCore.DAL.Interfaces;
using SCore.Models;
using SCore.Models.Models;
using System.Collections.Generic;

namespace SCore.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork db { get; set; }
        private readonly IFileManager _fileManager;
        public ProductService(IUnitOfWork _db,IFileManager fileManager)
        {
            db = _db;
            _fileManager = fileManager;
        }

        public void Create(ProductViewModel model)
        {
            Product product = new Product
            {
                ProductId = model.ProductId,
                Date = model.Date,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            };
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
