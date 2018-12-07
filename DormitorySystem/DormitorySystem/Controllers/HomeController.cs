using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using DormitorySystem.Web.Models.SensorsViewModels;

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
        public JsonResult GetPublicSensors()
        {
            var data = this.sensorService.GetPublicSensors()
                .Select(s=>new PublicSensorsCoordinatesModel(s));
            return Json(data);
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
    }
}
