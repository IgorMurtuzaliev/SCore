using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Interfaces;
using SCore.BLL.Models;
using SCore.WEB.ViewModels;

namespace SCore.WEB.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _rolesService;
        public RoleController(IRoleService rolesService)
        {
            _rolesService = rolesService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_rolesService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var createRole = new CreateRoleModel { Name = model.Name };
               var result = await _rolesService.Create(createRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string id)
        {
            await _rolesService.Edit(id);
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(RoleViewModelEdit model)
        {
            if (ModelState.IsValid)
            {
                var edit = new EditRoleModel { Name = model.Name, Id = model.Id };
                var result = await _rolesService.Edit(edit);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            await _rolesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}