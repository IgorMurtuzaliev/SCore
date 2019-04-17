using SCore.BLL.Interfaces;
using SCore.DAL.Interfaces;
using SCore.Models;
using SCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork db { get; set; }
        public OrderService(IUnitOfWork _db)
        {
            db = _db;
        }

        public void Create(OrderViewModel orderVM)
        {
            var order = new Order
            {
                UserId = orderVM.UserId,
                TimeOfOrder = DateTime.Now
            };

            var orderproduct = new ProductOrder
            {
                ProductId = orderVM.ProductId,
                Amount = orderVM.Amount,
            };

            order.ProductOrders.Add(orderproduct);
            db.Orders.Create(order);
            db.Save();
        }

        public Order Get(int id)
        {
            return db.Orders.Get(id);
        }


        public IEnumerable<Order> GetAll()
        {
            return db.Orders.GetAll();
        }

        public void Edit(Order order)
        {
            db.Orders.Edit(order);
            db.Orders.Save();
        }

        public void Delete(int id)
        {
            db.Orders.Delete(id);
            db.Orders.Save();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose(disposing);
        }

    }
}
