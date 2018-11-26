using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult>Details(string id)
        {
            var user = this._userService.GetUser(id); 
            var roles= await this._userManager.GetRolesAsync(user);
            return View(new UserViewModel(user, string.Join(", ", roles)));
        }
        public async Task<IActionResult> AssignRoles(string id)
        {
            var user = this._userService.GetUser(id);
            var result = await this._userManager.AddToRoleAsync(user, "Admin");
            return View();
        }
        public IActionResult Sensors(string id)
        {
            return View();
        }
    }
}