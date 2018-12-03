using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Data.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;

namespace DormitorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorsService sensorService;
        private readonly IUsersService userService;
        private readonly UserManager<User> userManager;

        public HomeController
            (ISensorsService sensorService,
             IUsersService userService,
             UserManager<User> userManager)
        {
            this.sensorService = sensorService;
            this.userService = userService;
            this.userManager = userManager;
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

            return View();
        }
    }
}
