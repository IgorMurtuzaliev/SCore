using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Infrastructure;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.Models;
using SCore.WEB.ViewModels;

namespace SCore.WEB.Controllers
{
    public class CartController : Controller
    {

        private IProductService repository;

        public CartController(IProductService repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Get(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", "Products");
        }

        public RedirectToActionResult RemoveFromCart(int productId,
                 string returnUrl)
        {
            Product product = repository.Get(productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
        public ActionResult CartSummary()
        {
            Cart cart = GetCart();
            return PartialView("~/Views/Cart/_CartSummary.cshtml", cart);
        }


    }
}