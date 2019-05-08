using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCore.BLL.Interfaces;
using SCore.DAL.EF;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace SCore.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        private readonly ISearchService service;
        private readonly IOrderService orderService;
        private readonly UserManager<User> manager;
        private readonly IFileManager fileManager;
        public HomeController(ISearchService _service, IOrderService _orderService, ApplicationDbContext _context, UserManager<User> _manager, IFileManager _fileManager)
        {
            service = _service;
            orderService = _orderService;
            context = _context;
            manager = _manager;
            fileManager = _fileManager;
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
            if (from != null || to != null)
            {
               var orders= service.FindByDate(from,to);
                return View(orders);
            }
            if (search != null)
            {
                var orders = service.FindByUser(search);
                return View(orders);
            }
            return View();
        }

        public FileResult ExportToExcel(DateTime? from, DateTime? to, string search)
        {
            DataTable dataTable = new DataTable("Grid");
            dataTable.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("User"),
                new DataColumn("OrderId"),
                new DataColumn("Order time"),
            });
            var orders = from != null && to!=null? service.FindByDate(from, to):search!=null? service.FindByUser(search):orderService.GetAll();
            foreach (var order in orders)
            {
                dataTable.Rows.Add(order.User.UserName, order.OrderId, order.TimeOfOrder);
            }
            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using(MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.orenxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
        
    }
}