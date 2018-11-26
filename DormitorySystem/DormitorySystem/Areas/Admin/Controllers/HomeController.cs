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
        private readonly UserManager<Data.Models.User> _userManager;

        public HomeController(IUserService userService, 
            UserManager<Data.Models.User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
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

        public IActionResult Details(string id)
        {
            var user = this._userService.GetUser(id);
            return View(new UserViewModel(user));
        }
        public IActionResult AssignRoles(string id)
        {
            return View();
        }
        public IActionResult Sensors(string id)
        {
            return View();
        }
    }
}