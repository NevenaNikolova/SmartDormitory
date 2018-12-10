using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.AppServices;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DormitorySystem.Tests.AppServicesTests.SensorServiceTests
{
    [TestClass]
    public class GetSampleSensorAsync_Should
    {
        [TestMethod]
        public async Task ReturnProperSensor_WhenValidValueIsPassed()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ReturnProperSensor_WhenValidValueIsPassed")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();
            var measure = new Measure
            {
                Id=1,
                MeasureType="test"
            };
            var sensorType = new SensorType
            {
                Id = 1,
                Name = "Test"
            };
            var sampleSensor = new SampleSensor
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Tag = "Test Sensor",
                Description = "Test Sensor",
                MinPollingInterval=20,
                MeasureId=measure.Id,
                ValueCurrent=50,
                SensorTypeId=sensorType.Id,
                IsOnline=true
            };
            //Act
            using (var actContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                actContext.Measures.Add(measure);
                actContext.SensorTypes.Add(sensorType);
                actContext.SampleSensors.Add(sampleSensor);
                actContext.SaveChanges();
            }

            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new SensorService(assertContext);
                var result = await service.GetSampleSensorAsync(sampleSensor.Id);
               
                Assert.AreEqual(sampleSensor.Tag, result.Tag);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SensorNullableException))]
        public async Task ThrowSensorNullableException_WhenInvalidValueIsPassed()
        {
            //Arrange
            var contextOptions = new DbContextOptionsBuilder<DormitorySystemContext>()
                .UseInMemoryDatabase("ThrowSensorNullableException_WhenInvalidValueIsPassed")
                .Options;

            var seedUsersMock = new Mock<ISeedUsers>();
            var seedApiDataMock = new Mock<ISeedApiData>();

            //Assert
            using (var assertContext = new DormitorySystemContext(contextOptions,
                seedUsersMock.Object, seedApiDataMock.Object))
            {
                var service = new SensorService(assertContext);
                var guid = Guid.Parse("00000000-0000-0000-0000-000000000001");
                var result = await service.GetSampleSensorAsync(guid);
            }
        }
    }
}
