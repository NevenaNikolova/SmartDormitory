using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserSensorService _userSensorService;

        public HomeController(IUserService userService, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, IUserSensorService userSensorService)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _userSensorService = userSensorService;
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
          
            this.TempData["Success-Message"] = $"User {user.Email} added to {role} role!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ListUserSensors(string id)
        {
            var userSensors = this._userService.ListSensors(id)
                .Select(us => new UserSensorViewModel(us))
                .ToList();
            if (userSensors == null)
            {
                return NoContent();
            }
            return View(new ListUserSensorsViewModel(userSensors));
        }
        [HttpGet]
        public IActionResult EditSensor(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var userSensor = this._userSensorService.GetSensor(id);

            if (userSensor == null)
            {
                return NotFound();
            }
            return View(new UserSensorViewModel(userSensor));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSensor([Bind(include: "Id, Name, UserPollingInterval, Latitude, Longitude, SendNotification, IsPrivate")]UserSensorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var sensor = this._userSensorService.EditSensor(model.Id, model.Name, model.UserPollingInterval,
                model.Latitude, model.Longitude, model.SendNotification, model.IsPrivate);

            return this.RedirectToAction("ListUserSensors", "Home", new { id = sensor.UserId });
        }

        public IActionResult AllSensors()
        {
            var userSensors = this._userService.ListSensors()
                .Select(us => new UserSensorViewModel(us))
                .ToList();
            if (userSensors == null)
            {
                return NoContent();
            }
            return View(new ListUserSensorsViewModel(userSensors));
        }
    }
}