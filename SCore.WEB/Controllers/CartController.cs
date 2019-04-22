using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.WEB.ViewModels;

namespace SCore.WEB.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        public CartController(ICartService _cartService)
        {
            cartService = _cartService;

        }
        public IActionResult Index(Cart cart)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart
            });

        }
        public ActionResult AddToCart(Cart cart, int? id)
        {
            cartService.AddToCart(cart, id);
            return RedirectToAction("Index","Products");
        }

        public ActionResult RemoveFromCart(Cart cart, int? id)
        {
            cartService.RemoveFromCart(cart, id);
            return RedirectToAction("Index");
        }
        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}