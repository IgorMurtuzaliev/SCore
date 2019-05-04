using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly UserManager<User> manager;
        private ApplicationDbContext context;
        public SearchService( ApplicationDbContext _context, UserManager<User> _manager)
        {
            context = _context;
            manager = _manager;
        }
        public List<Order> FindByDate(DateTime? from, DateTime? to)
        {
            return context.Orders.Where(c => c.TimeOfOrder > from && c.TimeOfOrder < to).ToList();
        }

        public List<Order> FindByUser(string search)
        {
            return context.Orders.Where(p => p.User.Name.Contains(search) || p.User.LastName.Contains(search) || p.User.UserName.Contains(search)).ToList();
        }
    }
}
