using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Models;
using DormitorySystem.Services.Abstractions;

namespace DormitorySystem.Controllers
{
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // only for test purpose 
        public IActionResult Test()
        {
            this.sensorService.GetSensorsByType();
            return View();
        }
    }
}
