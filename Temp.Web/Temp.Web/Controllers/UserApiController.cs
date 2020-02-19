using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly IUserService _service;

        public UserApiController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }
    }
}