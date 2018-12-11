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
    public class RegisterNewSensorAction_Should
    {
        [TestMethod]
        public async Task Return_RegisterNewSensorView()
        {          
            var sensorsService = new Mock<ISensorsService>();      
            var mockUserManager = GetUserManagerMock();
            var testSampleSensor = GetSampleSensor();
            var user = GetUser();

            sensorsService.Setup(s => s.GetSampleSensorAsync(It.IsAny<Guid>())).
                ReturnsAsync(testSampleSensor);

            var controller = new SensorsController(sensorsService.Object, mockUserManager.Object);

            var result = await controller.RegisterNewSensor(testSampleSensor.Id, user.Id) as ViewResult;

            Assert.AreEqual("RegisterNewSensor", result.ViewName);
        }

        [TestMethod]
        public async Task ReturnUserSensor_AsRegisterSensorModel()
        {
            var sensorsService = new Mock<ISensorsService>();
            var mockUserManager = GetUserManagerMock();
            var testSampleSensor = GetSampleSensor();
            var user = GetUser();

            sensorsService.Setup(s => s.GetSampleSensorAsync(It.IsAny<Guid>())).
                ReturnsAsync(testSampleSensor);

            var controller = new SensorsController(sensorsService.Object, mockUserManager.Object);
            var result = await controller.RegisterNewSensor(testSampleSensor.Id, user.Id) as ViewResult;
            var viewModel = (RegisterSensorModel)result.ViewData.Model;

            Assert.AreEqual(testSampleSensor.Id, viewModel.SampleSensorId);
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
        private static SampleSensor GetSampleSensor()
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
            return sampleSensor;
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
