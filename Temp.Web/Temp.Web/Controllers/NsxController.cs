using Microsoft.AspNetCore.Mvc;
using Temp.Service.DTO;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    public class NsxController : Controller
    {
        private readonly INsxService _nsxService;

        public NsxController(INsxService nsxService)
        {
            _nsxService = nsxService;
        }

        public IActionResult Index()
        {
            var nsx = _nsxService.GetAll();
            return View(nsx);
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            if (id <= 0)
            {
                return View();
            }
            return View(_nsxService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(NsxDto nsxDto)
        {
            _nsxService.Save(nsxDto);
            return RedirectToAction("Index", "Nsx");
        }

        public IActionResult Delete(int id)
        {
            _nsxService.Delete(id);
            return RedirectToAction("Index", "Nsx");
        }
    }
}