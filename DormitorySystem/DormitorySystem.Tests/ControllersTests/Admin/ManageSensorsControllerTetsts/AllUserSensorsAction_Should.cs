using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Admin.Controllers;
using DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.ControllersTests.Admin.ManageSensorsControllerTetsts
{
    [TestClass]
    public class AllUserSensorsAction_Should
    {
        [TestMethod]
        public async Task Return_AllUserSensorsView()
        {
            var sensorsService = new Mock<ISensorsService>();
            var user = GetUser();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.ListSensorsAsync("all")).
                ReturnsAsync(new List<UserSensor>() { testSensor });

            var controller = new ManageSensorsController(sensorsService.Object);

            var result = await controller.AllUserSensors() as ViewResult;

            Assert.AreEqual("AllUserSensors", result.ViewName);
        }

        [TestMethod]
        public async Task ReturnAllUserSensors_AsAllSensorSViewModel()
        {
            var sensorsService = new Mock<ISensorsService>();
            var user = GetUser();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.ListSensorsAsync("all")).
                ReturnsAsync(new List<UserSensor>() { testSensor });

            var controller = new ManageSensorsController(sensorsService.Object);

            var result = await controller.AllUserSensors() as ViewResult;

            var viewModel = (AllSensorSViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.AllUserSensors.Count());
        }
        private static User GetUser()
        {
            var user = new User()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com",
                UserName = "Test"
            };
            return user;
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
