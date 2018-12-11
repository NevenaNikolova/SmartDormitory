using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.AppServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.AppServicesTests.UserServiceTests
{
    [TestClass]
    public class GetUserWithSensorsAsync_Should
    {
        [TestMethod]
        public async Task ReturnProperUserWithSensors_WhenValidIdIsPassed()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnProperUserSensor_WhenValidIdIsPassed")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            var user = new User
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Email = "new@user.com",
                Sensors = new List<UserSensor>()
            };

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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000222"),
                Tag = "Test Sensor",
                Description = "Test Sensor",
                MinPollingInterval = 20,
                MeasureId = measure.Id,
                ValueCurrent = 50,
                SensorTypeId = sensorType.Id,
                IsOnline = true
            };
            var userSensor = new UserSensor
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                CreatedOn = DateTime.Now,
                isDeleted = false,
                SampleSensorId = sampleSensor.Id,
                PollingInterval = 100,
                SendNotification = true,
                IsPrivate = false,
                UserId=user.Id
            };          

            //Act
            using (var actContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                actContext.Users.Add(user);
                actContext.UserSensors.Add(userSensor);                
                actContext.SaveChanges();
            }
            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new UserService(assertContext);
                var result = await service.GetUserWithSensorsAsync(user.Id);

                Assert.AreEqual(1, result.Sensors.Count());
                Assert.AreEqual(userSensor.Id, result.Sensors.First().Id);
            }
        }
    }
}
