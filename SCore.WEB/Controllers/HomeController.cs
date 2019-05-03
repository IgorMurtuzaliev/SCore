using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.Models;
using System;
using System.Collections.Generic;

namespace SCore.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        private readonly ISearchService service;
        private readonly IOrderService orderService;
        private readonly UserManager<User> manager;
        public HomeController(ISearchService _service, IOrderService _orderService, ApplicationDbContext _context, UserManager<User> _manager)
        {
            service = _service;
            orderService = _orderService;
            context = _context;
            manager = _manager;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult FindData()
        {
            //ViewBag.UserId = new SelectList(context.Users, "Id", "UserName");
            var qq = orderService.GetAll();
            return View(qq);
        }
        [HttpPost]
        public ActionResult FindData(DateTime? from, DateTime? to, User user)
        {
            if (from != null || to != null)
            {
               var orders= service.FindByDate(from,to);
                return View(orders);
            }
            //if (user != null)
            //{
            //    var orders = service.FindByUser(user);
            //    return View(orders);
            //}
            return View();
        }
    }
}