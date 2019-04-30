using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.DAL.EF;
using SCore.Models;
using SCore.Models.Models;

namespace SCore.WEB.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db;
        private readonly IOrderService orderService;
        private readonly UserManager<User> userManager;
        private Cart cart;
        public OrdersController(IOrderService _orderService, ApplicationDbContext _db, UserManager<User> _userManager, Cart _cart)
        {
            orderService = _orderService;
            db = _db;
            userManager = _userManager;
            cart = _cart;
        }
        public ActionResult Index()
        {
            return View(orderService.GetAll());
        }

        public ActionResult Details(int id)
        {
            Order order = orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

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

        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        { 
           if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                var id = userManager.GetUserId(HttpContext.User);
                order.UserId = id;
                order.User = await userManager.FindByIdAsync(id);
                order.Lines = cart.Lines.ToArray();
                orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
           }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

    }
}