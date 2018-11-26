using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        //private readonly UserManager<Data.Models.User> _userManager;

        public HomeController(IUserService userService)      
        {
            _userService = userService;        
        }

        public IActionResult Index()
        {
            var users = this._userService.ListUsers()
                .Select(u => new UserViewModel(u));

            if (users.Count() == 0)
            {
                return RedirectToAction("Index");
            }

            return View(new ListUsersViewModel(users));
        }
    }
}