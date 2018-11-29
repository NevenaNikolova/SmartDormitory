using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        private readonly IUserSensorService sensorService;
        private readonly IUserService userService;
        private readonly UserManager<Data.Models.User> userManager;

        public HomeController(
            IUserSensorService sensorService,
            IUserService userService,
            UserManager<Data.Models.User> userManager)
        {
            this.sensorService = sensorService;
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var sensors = this.userService.ListSensors(userId);
            return View();
        }

        [HttpGet]
        public IActionResult RegisterNewSensor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewSensor(string somting)
        {
            return View();
        }
    }
}