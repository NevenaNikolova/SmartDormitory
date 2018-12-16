using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Common.Exceptions;
using DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUsersService usersService;

        public ManageUsersController
            (UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            User user;
            try
            {
                user = await this.usersService.GetUserWithSensorsAsync(id);
            }
            catch (UserNullableException ex)
            {
                this.TempData["Service-Error"] = ex.Message;
                return View("ServiceError");
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var model = new UserModel(user, string.Join(", ", roles));
            return View("UserDetails", model);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                this.TempData["Service-Error"] = "There is no such user.";
                return View("ServiceError");
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var model = new UserWithRolesModel(user, roles);

            return View("Roles", model);
        }

        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name,
                });

            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                this.TempData["Service-Error"] = "There is no such user.";
                return View("ServiceError");
            }

            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (!roleExists)
            {
                this.TempData["Service-Error"] = "There is no such role.";
                return View("ServiceError");
            }

            await this.userManager.AddToRoleAsync(user, role);

            this.TempData["Success-Message"] = $"User {user.Email} added to {role} role!";

            return RedirectToAction("UserDetails", new { id = user.Id });
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            User user;
            try
            {
                user = await this.usersService.DeleteUserAsync(id);
            }
            catch (UserNullableException ex)
            {
                this.TempData["Service-Error"] = ex.Message;
                return View("ServiceError");
            }

            return RedirectToAction("UserDetails", new { id = user.Id });
        }
    }
}