using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        private readonly IUserSensorService _userSensorService;

        public HomeController(IUserSensorService userSensorService)
        {
            _userSensorService = userSensorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListSampleSensors()
        {
            var sampleSensors = this._userSensorService.ListSampleSensors()
                .Select(s => new SampleSensorViewModel(s));

            if (sampleSensors == null)
            {
                throw new SensorNullableException("No sensors at the moment.");
            }

            return View(new ListSampleSensorsViewModel(sampleSensors));
        }

        [HttpGet]
        public IActionResult RegisterNewSensor(SampleSensorViewModel sampleSensor)
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