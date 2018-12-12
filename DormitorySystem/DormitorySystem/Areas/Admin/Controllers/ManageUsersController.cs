﻿using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.AppServices;
using DormitorySystem.Services.Exceptions;
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
            var user = await this.usersService.GetUserWithSensorsAsync(id);
            var roles = await this.userManager.GetRolesAsync(user);

            var model = new UserModel(user, string.Join(", ", roles));
            return View("UserDetails", model);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new UserNullableException("There is no such user.");
            }
            var roles = await this.userManager.GetRolesAsync(user);

            var model = new UserWithRolesModel(user, roles);

            return View(model);
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
            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (user == null || !roleExists)
            {
                return NotFound();
            }
            await this.userManager.AddToRoleAsync(user, role);

            this.TempData["Success-Message"] = $"User {user.Email} added to {role} role!";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await this.usersService.DeleteUserAsync(id);

            return RedirectToAction("UserDetails", new { id = user.Id });
        }

    }
}