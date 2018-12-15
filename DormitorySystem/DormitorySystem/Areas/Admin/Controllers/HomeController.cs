using DormitorySystem.Common.Exceptions;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Models;
using DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users;
            try
            {
                users = await this.usersService.ListUsersAsync();
            }
            catch (UserNullableException ex)
            {
                this.TempData["Service-Error"] = ex.Message;
                return View("ServiceError");
            }

            var model = users.Select(u => new UserModel(u));

            return View("Index", model);
        }
    }
}