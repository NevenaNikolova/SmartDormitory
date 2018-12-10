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

namespace DormitorySystem.Tests.AppServicesTests.SensorServiceTests
{
    [TestClass]
    public class GetPublicSensorsAsync_Should
    {
        [TestMethod]
        public async Task ReturnEmptyCollection_WhenNoPublicSensors()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnEmptyCollection_WhenNoPublicSensors")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new SensorService(assertContext);
                var result = await service.GetPublicSensorsAsync();

                Assert.AreEqual(0, result.Count());
            }
        }
        [TestMethod]
        public async Task ReturnPublicSensors_WhenCollectionIsNotEmpty()
        {
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnPublicSensors_WhenCollectionIsNotEmpty")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();
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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CreatedOn = DateTime.Now,
                isDeleted = false,
                SampleSensorId = sampleSensor.Id,
                PollingInterval = 100,
                SendNotification = true,
                IsPrivate = false
            };

            //Act
            using (var actContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                actContext.Measures.Add(measure);
                actContext.SensorTypes.Add(sensorType);
                actContext.SampleSensors.Add(sampleSensor);
                actContext.UserSensors.Add(userSensor);
                actContext.SaveChanges();
            }
            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new SensorService(assertContext);
                var result = await service.GetPublicSensorsAsync();

                Assert.AreEqual(1, result.Count());
            }
        }
    }
}
