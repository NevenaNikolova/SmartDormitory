using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public HomeController(IUserService userService, 
            UserManager<Data.Models.User> userManager,
           RoleManager<IdentityRole>roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
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
        public async Task<IActionResult> Roles(string id)
        {
            var user = await this._userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new UserNullableException("There is no such user.");
            }
            var roles = await this._userManager.GetRolesAsync(user);
            return View(new UserWithRolesViewModel
            {
                Id=user.Id,
                UserName=user.UserName,
                Email=user.Email,
                Roles=roles
            });
        }
        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = this._roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();
            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            var user = await this._userManager.FindByIdAsync(id);
            var roleExists = await this._roleManager.RoleExistsAsync(role);

            if (user == null||!roleExists)
            {
                return NotFound();
            }
            await this._userManager.AddToRoleAsync(user, role);
          
            TempData["SuccessMessage"] = $"User {user.Email} added to {role} role!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Sensors(string id)
        {
            return View();
        }
    }
}