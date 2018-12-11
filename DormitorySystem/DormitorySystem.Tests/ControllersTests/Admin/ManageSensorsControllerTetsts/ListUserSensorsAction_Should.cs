using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DormitorySystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels;
using System.Linq;

namespace DormitorySystem.Tests.ControllersTests.Admin.ManageSensorsControllerTetsts
{
    [TestClass]
    public class ListUserSensorsAction_Should
    {
        [TestMethod]
        public async Task Return_ListUserSensorsView()
        {
            var sensorsService = new Mock<ISensorsService>();          
            var user = GetUser();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.ListSensorsAsync(user.Id)).
                ReturnsAsync(new List<UserSensor>() { testSensor });

            var controller = new ManageSensorsController(sensorsService.Object);

            var result = await controller.ListUserSensors(user.Id, user.UserName) as ViewResult;

            Assert.AreEqual("ListUserSensors", result.ViewName);
        }

        [TestMethod]
        public async Task ReturnUserSensors_AsListSensorSViewModel()
        {
            var sensorsService = new Mock<ISensorsService>();
            var user = GetUser();
            var testSensor = TestUserSensor();

            sensorsService.Setup(s => s.ListSensorsAsync(user.Id)).
                ReturnsAsync(new List<UserSensor>() { testSensor });

            var controller = new ManageSensorsController(sensorsService.Object);

            var result = await controller.ListUserSensors(user.Id, user.UserName) as ViewResult;

            var viewModel = (ListSensorSViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.UserSensors.Count());
        }
        private static User GetUser()
        {
            var user = new User()
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com",
                UserName="Test"
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
