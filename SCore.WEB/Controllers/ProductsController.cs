using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.Models;
using SCore.Models.Models;
using SCore.WEB.ViewModels;

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
            var product = new ProductModel
            {
                Date = model.Date,
                Description = model.Description,
                Images = model.Images,
                Name = model.Name,
                Price = model.Price,
                ProductId = model.ProductId
            };
            if (ModelState.IsValid)
            {
                productService.Create(product);
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
        public ActionResult Edit(ProductViewModel model)
        {
            var product = new ProductModel
            {
                ProductId = model.ProductId,
                Date = model.Date,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,

            };
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