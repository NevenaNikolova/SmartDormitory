using DormitorySystem.Services.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DormitorySystem.Web.Areas.Admin.Controllers;
using Moq;
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels;
using System.Linq;

namespace DormitorySystem.Tests.ControllersTests.Admin.HomeControllerTests
{
    [TestClass]
    public class IndexAction_Should
    {
        [TestMethod]
        public async Task Return_IndexView()
        {
            var usersService = new Mock<IUsersService>();           
            var user = GetUser();
            
            usersService.Setup(s => s.ListUsersAsync()).
                ReturnsAsync(new List<User>() { user });

            var controller = new HomeController(usersService.Object);

            var result = await controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public async Task ReturnAllUsers_AsUserViewModel()
        {
            var usersService = new Mock<IUsersService>();
            var user = GetUser();

            usersService.Setup(s => s.ListUsersAsync()).
                ReturnsAsync(new List<User>() { user });

            var controller = new HomeController(usersService.Object);

            var result = await controller.Index() as ViewResult;

            var viewModel = (IEnumerable<UserModel>)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Count());
        }
        private static User GetUser()
        {
            var user = new User()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com",
            };
            return user;
        }
    }
}
