using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Common.Infrastructure;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// admin controller
    /// </summary>
    [Authorize(Policy = Constants.Role.Manager)]
    public class AdminController : Controller
    {
        /// <summary>
        /// view home admin
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            return View("Index", user);
        }
    }
}