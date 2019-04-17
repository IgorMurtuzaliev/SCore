using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.Models;
using SCore.Models.Models;

namespace SCore.WEB.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db;
        private readonly IOrderService orderService;
        public OrdersController(IOrderService _orderService, ApplicationDbContext _db)
        {
            orderService = _orderService;
            db = _db;
        }
        // [MyAction]
        public ActionResult Index()
        {
            return View(orderService.GetAll());
        }
        //[MyAction]
        public ActionResult Details(int id)
        {
            Order order = orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
       // [MyAction]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel orderVM)
        {
            //[Bind(Include = "OrderId,TimeOfOrder,UserId")] 

            if (ModelState.IsValid)
            {
                orderService.Create(orderVM);

                return RedirectToAction("Index");
            }
            return View(orderVM);
        }

        public ActionResult Edit(int id)
        {
            
            Order order = orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", order.UserId);
            return View(order);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                orderService.Edit(order);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", order.UserId);
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            Order order = orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose(disposing);
        }
    }
}