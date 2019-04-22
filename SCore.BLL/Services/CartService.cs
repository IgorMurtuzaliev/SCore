using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.DAL.Interfaces;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Services
{
    public class CartService : ICartService
    {
    

        IUnitOfWork db { get; set; }
        public CartService(IUnitOfWork _db)
        {
            db = _db;
        }
        public void AddToCart(Cart cart, int? id)
        {
            Product product = db.Products.Get(id);
            if (id == null)
            {
                new BadRequestResult();
            }

            if (product != null)
            {
              cart.AddItem(product, 1);
            }
        }

        public void RemoveFromCart(Cart cart, int? id)
        {
            Product product = db.Products.Get(id);
            if (id == null)
            {
                new BadRequestResult();
            }

            if (product != null)
            {
                cart.RemoveLine(product);
            }
        }

    }
}
