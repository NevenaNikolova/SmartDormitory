using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }
    }
}