using System;
using System.Linq;
using DormitorySystem.Common.Constants;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models;
using DormitorySystem.Web.Models.SensorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageSensorsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ISensorsService sensorsService;

        public ManageSensorsController(IUsersService usersService, UserManager<User> userManager, 
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
        public IActionResult ListUserSensors(string id)
        {
            var userSensors = this.sensorsService.ListSensors(id)
                .Select(us => new UserSensorViewModel(us))
                .ToList();

            if (userSensors == null)
            {
                return NoContent();
            }

            var model = new ListUserSensorsViewModel(userSensors, id);

            return View(model);
        }
        [HttpGet]
        public IActionResult EditSensor(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var userSensor = this.sensorsService.GetUserSensor(id);

            if (userSensor == null)
            {
                return NotFound();
            }
            return View(new UserSensorViewModel(userSensor));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSensor
            ([Bind(include: WebConstants.UserSensorViewModelBindingString)] UserSensorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

           // var sensor = this.sensorsService.EditSensor();

            return this.RedirectToAction("ListUserSensors", "ManageSensors", new { id = model.UserId });
        }

        public IActionResult AllUserSensors()
        {
            var userSensors = this.sensorsService.ListSensors()
                .Select(us => new UserSensorViewModel(us))
                .ToList();
            if (userSensors == null)
            {
                return NoContent();
            }
            return View(userSensors);
        }
    }
}