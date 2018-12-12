using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using DormitorySystem.Web.Models.SensorsViewModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace DormitorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorsService sensorService;
        private readonly IUsersService userService;
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache memoryCache;

        public HomeController
            (ISensorsService sensorService,
             IUsersService userService,
             UserManager<User> userManager,
             IMemoryCache memoryCache)
        {
            this.sensorService = sensorService;
            this.userService = userService;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetPublicSensors()
        {
            var publicSensors = await this.memoryCache.GetOrCreateAsync
                ("PublicSensors", async entry =>
             {
                 entry.AbsoluteExpiration = DateTime.UtcNow.AddDays(12);
                 var returnResult = await this.sensorService.GetPublicSensorsAsync();
                 return returnResult;
             });

            var data = publicSensors.Select(s => new SensorsCoordinatesModel(s));

            return Json(data);
        }

        [ResponseCache(Duration = 7200)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 7200)]
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
