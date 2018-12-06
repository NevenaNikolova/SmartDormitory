using System;
using System.Linq;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.Users.Models;
using DormitorySystem.Web.Models.SensorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User, Admin")]
    public class SensorsController : Controller
    {
        private readonly ISensorsService sensorsService;
        private readonly UserManager<User> userManager;
        private readonly IUsersService usersService;

        public SensorsController(
            ISensorsService userSensorService,
            UserManager<User> userManager,
            IUsersService userService)
        {
            this.sensorsService = userSensorService;
            this.usersService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = this.userManager.GetUserId(HttpContext.User);
            var userSensors = this.sensorsService.ListSensors(user);
            var model = userSensors.Select(us => new UserIndexViewModel(us)).ToList();

            return View(model);
        }

        public IActionResult SensorDetails(Guid userSensorid)
        {
            var model = new UserSensorViewModel(this.sensorsService.GetUserSensor(userSensorid));
            return View(model);
        }

        public IActionResult ListSampleSensors(string userId)
        {
            var sampleSensors = this.sensorsService.ListSampleSensors()
                .Select(s => new SampleSensorViewModel(s));

            var a = userId;

            if (sampleSensors == null)
            {
                throw new SensorNullableException("No sensors at the moment.");
            }

            var model = new ListSampleSensorViewModel(sampleSensors, userId);

            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterNewSensor
            (Guid sampleSensorId, string userId, string tag, string description)
        {
            var model = new UserSensorViewModel()
            {
                UserId = userId,
                SampleSensorId = sampleSensorId,
                SampleSensor = new SampleSensor
                {
                    Tag = tag,
                    Description = description,
                    // TO DO Add min polling interval in model and Sensor Type in View
                    MinPollingInterval = 0,
                    SensorType = null
                }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewSensor
            ([Bind(include: "UserId, SampleSensorId, Name, UserPollingInterval, Latitude, Longitude, SendNotification, IsPrivate, UserMinValue, UserMaxValue")]
                     UserSensorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.UserId == null)
            {
                model.UserId = this.userManager.GetUserId(HttpContext.User);
            }

            var sensor = this.sensorsService.RegisterSensor(
                model.UserId,
                model.SampleSensorId,
                model.Name,
                model.UserPollingInterval,
                model.Latitude,
                model.Longitude,
                model.SendNotification,
                model.IsPrivate
                );

            this.TempData["Success-Message"] = $"Sensor {sensor.Name} was registered successfully!";

            return this.RedirectToAction("ListSampleSensors", new { userId = model.UserId });
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
        public IActionResult EditSensor([Bind(include: "Id, Name, UserPollingInterval, Latitude, Longitude, SendNotification, IsPrivate")]UserSensorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var sensor = this.sensorsService.EditSensor(model.Id, model.Name, model.UserPollingInterval,
                model.Latitude, model.Longitude, model.SendNotification, model.IsPrivate);

            return this.RedirectToAction("Index", "Sensors");
        }
    }
}