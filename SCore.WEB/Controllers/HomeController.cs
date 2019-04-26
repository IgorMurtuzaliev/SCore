using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCore.DAL.EF;
using SCore.Models;
namespace SCore.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        //[HttpGet]
        //public ActionResult FindData()
        //{
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
        //    return View(db.Orders.ToList());
        //}
        //[HttpPost]
        //public ActionResult FindData(DateTime? from, DateTime? to, User user)
        //{

        //    if (from != null || to != null)
        //    {
        //        var orders = db.Orders.Where(c => c.TimeOfOrder > from && c.TimeOfOrder < to).ToList();
        //        return View(orders);
        //    }
        //    return View();        
        //}
        
    }
}