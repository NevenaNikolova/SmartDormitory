using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        private readonly IUserSensorService sensorService;

        public HomeController(IUserSensorService sensorService)
        {
            this.sensorService = sensorService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ViewSensorTypes()
        {
            var model = new SensorsByTypeViewModel(this.sensorService.GetSensorsByType());
            return View(model);
        }

        [HttpGet]
        public IActionResult ListSensorByType(IEnumerable<SampleSensor> sensors)
        {
            return View(sensors);
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