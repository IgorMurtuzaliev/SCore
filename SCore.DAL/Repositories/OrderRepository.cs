using Microsoft.EntityFrameworkCore;
using SCore.DAL.EF;
using SCore.DAL.Interfaces;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCore.DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        private ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext context)
        {
            this.db = context;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }

        public void Edit(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
    }
}
