using System;
using System.Linq;
using DormitorySystem.Common.Constants;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.Users.Models;
using DormitorySystem.Web.Areas.Users.Models.SampleSensorsModels;
using DormitorySystem.Web.Areas.Users.Models.UserSensorsModels;
using DormitorySystem.Web.Models.SensorsViewModels;
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

        public SensorsController(
            ISensorsService userSensorService,
            UserManager<User> userManager)
        {
            this.sensorsService = userSensorService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = this.userManager.GetUserId(HttpContext.User);
            var userSensors = this.sensorsService.ListSensors(user);
            var model = userSensors.Select(us => new UserIndexModel(us)).ToList();

            return View(model);
        }

        public JsonResult ViewSensorsOnMap()
        {
            var user = this.userManager.GetUserId(HttpContext.User);
            var data = this.sensorsService.ListSensors(user)
                .Select(s => new SensorsCoordinatesModel(s));
            return Json(data);
        }

        public IActionResult SensorDetails(Guid userSensorid)
        {
            var userSensor = this.sensorsService.GetUserSensor(userSensorid);
            var model = new UserSensorDetailsModel(userSensor);
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
            var model = new RegisterSensorModel(sensor, userId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewSensor
            ([Bind(include: WebConstants.UserSensorViewModelBindingString)] RegisterSensorModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData["Lng-Lat"] = "Plaeas set the location of the sensor";
                return View(model);
            }
            if (model.UserMinValue>=model.UserMaxValue)
            {
                this.TempData["Invalid-Min-Max-Value"] = "MinValue can not be equal to or greater than MaxValue.";
                return View(model);
            }


            if (model.UserId == null)
            {
                model.UserId = this.userManager.GetUserId(HttpContext.User);
            }

            var registrationData = new UserSensor()
            {
                Name = model.Name,
                PollingInterval = model.UserPollingInterval,
                SampleSensorId = model.SampleSensorId,
                UserId = model.UserId,
                UserMinValue = model.UserMinValue,
                UserMaxValue = model.UserMaxValue,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                SendNotification = model.SendNotification,
                IsPrivate = model.IsPrivate
            };

            var sensor = this.sensorsService.RegisterSensor(registrationData);

            this.TempData["Success-Message"] = $"Sensor {sensor.Name} was registered successfully!";

            return this.RedirectToAction("SensorDetails", new { userSensorid = sensor.Id });
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

            var model = new EditSensorModel(userSensor);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSensor(
            [Bind(include: WebConstants.UserSensorViewModelBindingString)] EditSensorModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            if (model.UserMinValue >= model.UserMaxValue)
            {
                this.TempData["Invalid-Min-Max-Value"] = "MinValue can not be equal to or greater than MaxValue.";
                return View(model);
            }

            var editedSensor = new UserSensor()
            {
                Id = model.Id,
                Name = model.Name,
                PollingInterval = model.UserPollingInterval,
                SampleSensorId = model.SampleSensorId,
                UserId = model.UserId,
                UserMinValue = model.UserMinValue,
                UserMaxValue = model.UserMaxValue,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                SendNotification = model.SendNotification,
                IsPrivate = model.IsPrivate
            };

            var sensor = this.sensorsService.EditSensor(editedSensor);

            return this.RedirectToAction("SensorDetails", new { userSensorid = sensor.Id });
        }
    }
}