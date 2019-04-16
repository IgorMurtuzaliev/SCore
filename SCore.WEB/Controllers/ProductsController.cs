using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.DAL.Repositories;
using SCore.Models;

namespace SCore.WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController(IProductService _productService)
        {
            productService = _productService;

        }
        public ActionResult Index()
        {
            return View(orderService.);
        }

        public ActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Create(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = productService.Get(id);
            return View(product);
        }

        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Edit(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

       // [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}