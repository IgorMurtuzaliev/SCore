using ClosedXML.Excel;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.Models;
using SCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SCore.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        private readonly ISearchService service;
        private readonly IOrderService orderService;
        private readonly UserManager<User> manager;
        private readonly IFileManager fileManager;
        private IHostingEnvironment _appEnvironment;
        public HomeController(ISearchService _service, IOrderService _orderService, ApplicationDbContext _context, UserManager<User> _manager, IFileManager _fileManager, IHostingEnvironment appEnvironment)
        {
            service = _service;
            orderService = _orderService;
            context = _context;
            manager = _manager;
            fileManager = _fileManager;
            _appEnvironment = appEnvironment;
        }
        public ActionResult Index()
        {            
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult FindData()
        {
            var orders = orderService.GetAll();
            return View(orders);
        }
        [HttpPost]
        public ActionResult FindData(DateTime? from, DateTime? to, string search)
        {
            ViewBag.From = from;
            ViewBag.To = to;
            ViewBag.Search = search;
            var orders = service.Search(from,to,search);
            return View(orders);
        }

        public FileResult ExportToExcel(DateTime? from, DateTime? to, string search)
        {
                using (MemoryStream stream = new MemoryStream())
                {
                    var wb = service.ExportToExcel(from,to,search);
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.orenxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
        }

        public async Task<IActionResult> SendEmailAsync(DateTime? from, DateTime? to, string search)
        {
            await service.SendByEmail(from, to, search);
            return RedirectToAction("FindData", "Home");
        }
    }
}