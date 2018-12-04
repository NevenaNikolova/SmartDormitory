using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;       

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;        
        }

        public IActionResult Index()
        {
            var users = this.usersService.ListUsers()
                .Select(u => new UserViewModel(u));

            if (users.Count() == 0)
            {
                return RedirectToAction("Index");
            }

            return View(users);
        }
    }
}