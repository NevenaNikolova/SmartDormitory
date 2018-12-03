using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.Admin.Models;
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
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ISensorsService sensorsService;

        public ManageUsersController(IUsersService usersService, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, ISensorsService sensorsService)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.sensorsService = sensorsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = this.usersService.GetUser(id);
            var roles = await this.userManager.GetRolesAsync(user);
            return View(new UserViewModel(user, string.Join(", ", roles)));
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new UserNullableException("There is no such user.");
            }
            var roles = await this.userManager.GetRolesAsync(user);
            return View(new UserWithRolesViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles
            });
        }

        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = this.roleManager
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
            var user = await this.userManager.FindByIdAsync(id);
            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (user == null || !roleExists)
            {
                return NotFound();
            }
            await this.userManager.AddToRoleAsync(user, role);

            this.TempData["Success-Message"] = $"User {user.Email} added to {role} role!";

            return RedirectToAction(nameof(Index));
        }

    }
}