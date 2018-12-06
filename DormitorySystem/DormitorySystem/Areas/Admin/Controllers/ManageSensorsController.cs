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
        public IActionResult ListUserSensors(string id, string userName)
        {
            var userSensors = this.sensorsService.ListSensors(id)
                .Select(us => new UserSensorViewModel(us))
                .ToList();

            if (userSensors == null)
            {
                return NoContent();
            }

            var model = new ListUserSensorsViewModel(userSensors, id, userName);

            return View(model);
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