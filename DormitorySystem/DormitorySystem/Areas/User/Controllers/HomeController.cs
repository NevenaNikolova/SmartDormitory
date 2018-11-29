using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Web.Areas.User.Models;
using DormitorySystem.Web.Models.SensorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        private readonly IUserSensorService _userSensorService;
        private readonly IUserService _userService;
        private readonly UserManager<Data.Models.User> _userManager;

        public HomeController(IUserSensorService userSensorService, 
            IUserService userService, UserManager<Data.Models.User> userManager)
        {
            _userSensorService = userSensorService;
            _userService = userService;
            _userManager = userManager;
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
        public IActionResult RegisterNewSensor()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterNewSensor(Guid sampleSensorId, [Bind(include: "sampleSensorId")]UserSensorViewModel model)
        {
            var userId = this._userManager.GetUserId(HttpContext.User);
           // this._userService.RegisterSensor(userId,model. )
            return View();
        }
    }
}