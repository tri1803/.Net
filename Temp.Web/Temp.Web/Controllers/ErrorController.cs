using Microsoft.AspNetCore.Mvc;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// Error controller
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// page not found(404)
        /// </summary>
        /// <returns></returns>
        public IActionResult PageNotFound()
        {
            return View();
        }
        
        /// <summary>
        /// access denied view(403)
        /// </summary>
        /// <returns></returns>
        public IActionResult NotPermission()
        {
            return View();
        }

    }
}