using System;
using System.Linq;
using DormitorySystem.Common.Constants;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Services.ServiceModels;
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

        public JsonResult ViewSensorsOnMap()
        {
            var user = this.userManager.GetUserId(HttpContext.User);
            var data = this.sensorsService.ListSensors(user)
                .Select(s=>new UserSensorsCoordinatesModel(s));         
            return Json(data);
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
        public IActionResult RegisterNewSensor(Guid sampleSensorId, string userId)
        {
            var sensor = this.sensorsService.GetSampleSensor(sampleSensorId);
            var model = new UserSensorViewModel(sensor, userId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewSensor
            ([Bind(include: WebConstants.UserSensorViewModelBindingString)] UserSensorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.UserId == null)
            {
                model.UserId = this.userManager.GetUserId(HttpContext.User);
            }

            var registrationData = ConvertUserSensorViewModelToServiceSensorModel(model);

            var sensor = this.sensorsService.RegisterSensor(registrationData);

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

            var model = new UserSensorViewModel(userSensor);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSensor(
            [Bind(include: WebConstants.UserSensorViewModelBindingString)] UserSensorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var editedSensor = ConvertUserSensorViewModelToServiceSensorModel(model);

            var sensor = this.sensorsService.EditSensor(editedSensor);

            return this.RedirectToAction("SensorDetails", new { userSensorid = sensor.Id});
        }

        private ServiceSensorModel ConvertUserSensorViewModelToServiceSensorModel
            (UserSensorViewModel userSensor)
        {
            var serviceSensorModel = new ServiceSensorModel()
            {
                Name = userSensor.Name,
                UserSensorId = userSensor.Id,
                UserId = userSensor.UserId,
                SampleSensorId = userSensor.SampleSensorId,
                UserPollingInterval = userSensor.UserPollingInterval,
                UserMinValue = userSensor.UserMinValue,
                UserMaxValue = userSensor.UserMaxValue,
                Latitude = userSensor.Latitude,
                Longitude = userSensor.Longitude,
                SendNotification = userSensor.SendNotification,
                IsPrivate = userSensor.IsPrivate
            };

            return serviceSensorModel;
        }
    }
}