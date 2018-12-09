using System.Linq;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageSensorsController : Controller
    {
        private readonly ISensorsService sensorsService;

        public ManageSensorsController(ISensorsService sensorsService)
        {
            this.sensorsService = sensorsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUserSensors(string id, string userName)
        {
            var userSensors = this.sensorsService.ListSensors(id)
                .Select(us => new ListSensorViewModel(us))
                .ToList();

            if (userSensors == null)
            {
                return NoContent();
            }

            var model = new ListSensorSViewModel(userSensors, id, userName);

            return View(model);
        }
        public IActionResult AllUserSensors()
        {
            var userSensors = this.sensorsService.ListSensors()
                .Select(us => new AllSensorViewModel(us))
                .ToList();
            if (userSensors == null)
            {
                return NoContent();
            }

            var model = new AllSensorSViewModel(userSensors);

            return View(model);
        }
    }
}