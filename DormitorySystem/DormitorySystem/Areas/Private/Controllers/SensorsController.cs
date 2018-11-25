using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.Private.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class SensorsController : Controller
    {
        public IActionResult ViewSensors()
        {
            return View();
        }
        public IActionResult RegisterSensor()
        {
            return View();
        }
        public IActionResult EditSensor()
        {
            return View();
        }
    }
}