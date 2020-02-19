using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Service.Service;
using Temp.Common.Infrastructure;
using Temp.Service.DTO;

namespace Temp.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetAll();
            return View(roles);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Save(int id)
        {
            if (id <= 0)
            {
                return View();
            }
            return View(_roleService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Constants.Role.Admin)]
        public IActionResult Save(RoleDto roleDto)
        {
            _roleService.Save(roleDto);
            return RedirectToAction("Index","Role");
        }

        [Authorize(Policy = Constants.Role.Admin)]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            return RedirectToAction("Index","Role");
        }
    }
}