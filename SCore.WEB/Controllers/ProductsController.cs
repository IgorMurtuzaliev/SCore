using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.Models;
using SCore.Models.Models;

namespace SCore.WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;
        public ProductsController(IProductService _productService, ICartService _cartService)
        {
            productService = _productService;
            cartService = _cartService;
        }
        public ActionResult Index()
        {
            return View(productService.GetAll());
        }

        public ActionResult Details(int id)
        {
            Product product = productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Product product = productService.Get(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Edit(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Product product = productService.Get(id);
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}