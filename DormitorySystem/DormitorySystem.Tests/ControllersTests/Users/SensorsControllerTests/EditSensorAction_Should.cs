using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Users.Controllers;
using DormitorySystem.Web.Areas.Users.Models.UserSensorsModels;
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

namespace DormitorySystem.Tests.ControllersTests.Users.SensorsControllerTests
{
    [TestClass]
    public class EditSensorAction_Should
    {
        [TestMethod]
        public async Task Return_EditSensorView()
        {           
            var sensorsService = new Mock<ISensorsService>();         
            var mockUserManager = GetUserManagerMock();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.GetUserSensorAsync(It.IsAny<Guid>())).
               ReturnsAsync(testSensor);

            var controller = new SensorsController(sensorsService.Object, mockUserManager.Object);

            var result = await controller.EditSensor(testSensor.Id) as ViewResult;

            Assert.AreEqual("EditSensor", result.ViewName);
        }

        [TestMethod]
        public async Task ReturnUserSensor_AsEditSensorModel()
        {
            var sensorsService = new Mock<ISensorsService>();
            var mockUserManager = GetUserManagerMock();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.GetUserSensorAsync(It.IsAny<Guid>())).
               ReturnsAsync(testSensor);

            var controller = new SensorsController(sensorsService.Object, mockUserManager.Object);

            var result = await controller.EditSensor(testSensor.Id) as ViewResult;
            var viewModel = (EditSensorModel)result.ViewData.Model;

            Assert.AreEqual(testSensor.Id, viewModel.Id);
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
        private static UserSensor TestUserSensor()
        {
            var measure = new Measure
            {
                Id = 1,
                MeasureType = "test"
            };
            var sensorType = new SensorType
            {
                Id = 1,
                Name = "Test"
            };
            var sampleSensor = new SampleSensor
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000333"),
                Tag = "Test Sensor",
                Description = "Test Sensor",
                MinPollingInterval = 20,
                MeasureId = measure.Id,
                Measure = measure,
                ValueCurrent = 50,
                SensorTypeId = sensorType.Id,
                SensorType = sensorType,
                TimeStamp = DateTime.Now.ToString(),
                IsOnline = true
            };
            var user = new User()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com",
            };
            var userSensor = new UserSensor
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000444"),
                Name = "Test",
                CreatedOn = DateTime.Now,
                isDeleted = false,
                SampleSensorId = sampleSensor.Id,
                SampleSensor = sampleSensor,
                PollingInterval = 100,
                UserMinValue = 100,
                UserMaxValue = 200,
                Latitude = "51.1524",
                Longitude = "55.546",
                SendNotification = true,
                IsPrivate = false,
                User = user,
                UserId = user.Id,
            };

            return userSensor;
        }
    }
}

