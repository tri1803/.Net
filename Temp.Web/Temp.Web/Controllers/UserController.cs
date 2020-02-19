using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Common.Infrastructure;
using Temp.Service.DTO;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// User controller 
    /// </summary>
    [Authorize(Policy = Constants.Role.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        
        /// <summary>
        /// usercontroller constructor
        /// </summary>
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        
        /// <summary>
        /// list user view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }
        
        /// <summary>
        /// button for request approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ApproveRequest(int id)
        {
            var user = _userService.GetById(id);
            _userService.ApproveRequestExpired(user);
            return RedirectToAction("Index", "User");
        }
        
        /// <summary>
        /// button for request reject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RejectRequest(int id)
        {
            var user = _userService.GetById(id);
            _userService.RejectRequestExpired(user);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            var roles = _roleService.GetAllRole();           
            if (id <= 0)
            {
                var viewInsert = new CreateUserDto
                {
                    Roles = roles
                };
                return View(viewInsert);
            }
            var viewEdit = _userService.GetUserEditById(id);
            viewEdit.Roles = roles;
            return View(viewEdit);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CreateUserDto userDto) 
        {
            _userService.Save(userDto, userDto.Avatar);
            return RedirectToAction("Index", "User");
            //var roles = _roleService.GetAllRole();
            //if (userDto.Id <= 0)
            //{
            //    var viewInsert = new CreateUserDto
            //    {
            //        Roles = roles
            //    };
            //    return View(viewInsert);
            //}
            //var viewEdit = _userService.GetUserEditById(userDto.Id);
            //viewEdit.Roles = roles;
            //return View(viewEdit);

        }

        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index", "User");
        }
    }
}