﻿using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Controllers;
using DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.ControllersTests.Admin.ManageUsersControllerTests
{
    [TestClass]
    public class UserDetailsAction_Should
    {
        [TestMethod]
        public async Task Return_UserDetailsView()
        {
            var userService = new Mock<IUsersService>();
            var mockUserManager = GetUserManagerMock();
            var mockRoleManager = GetRoleManagerMock();
            var user = GetUser();

            userService.Setup(u => u.GetUserWithSensorsAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            mockUserManager.Setup(u => u.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string>() {"User"});

            var controller = new ManageUsersController(mockUserManager.Object, mockRoleManager.Object, userService.Object);

            var result = await controller.UserDetails(user.Id) as ViewResult;

            Assert.AreEqual("UserDetails", result.ViewName);
        }
        [TestMethod]
        public async Task ReturnUser_AsUserViewModel()
        {
            var userService = new Mock<IUsersService>();
            var mockUserManager = GetUserManagerMock();
            var mockRoleManager = GetRoleManagerMock();
            var user = GetUser();

            userService.Setup(u => u.GetUserWithSensorsAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            mockUserManager.Setup(u => u.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync(new List<string>() { "User" });

            var controller = new ManageUsersController(mockUserManager.Object, mockRoleManager.Object, userService.Object);

            var result = await controller.UserDetails(user.Id) as ViewResult;

            var viewModel = (UserModel)result.ViewData.Model;

            Assert.AreEqual(user.Id, viewModel.Id);
        }

        private static Mock<UserManager<User>> GetUserManagerMock()
        {
            return new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);
        }
        private static Mock<RoleManager<IdentityRole>> GetRoleManagerMock()
        {
            return new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object);
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
