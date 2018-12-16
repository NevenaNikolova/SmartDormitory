using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Common.Exceptions;
using DormitorySystem.Data.Models;
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

        public async Task<IActionResult> ListUserSensors(string id, string userName)
        {
            var userSensors = await this.sensorsService.ListSensorsAsync(id);

            var sensorsData = userSensors.Select(us => new ListSensorViewModel(us));

            var model = new ListSensorSViewModel(sensorsData, id, userName);

            return View("ListUserSensors", model);
        }

        public async Task<IActionResult> AllUserSensors()
        {
            var userSensors = await this.sensorsService.ListSensorsAsync();

            var allSensors = userSensors.Select(us => new AllSensorViewModel(us));

            var model = new AllSensorSViewModel(allSensors);

            return View("AllUserSensors", model);
        }
    }
}