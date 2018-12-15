using System;
using DormitorySystem.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;
using DormitorySystem.Common.Exceptions;

namespace DormitorySystem.Controllers
{
    [Route("[controller]/value")]
    [ApiController]
    public class APIController
    {
        private readonly ISensorsService sensorsService;

        public APIController(ISensorsService userSensorService)
        {
            this.sensorsService = userSensorService;
        }

        [HttpGet]
        public async Task<JsonResult> Get(Guid sensorId)
        {
            SampleSensor sensor;
            try
            {
                sensor = await this.sensorsService.GetSampleSensorAsync(sensorId);
            }
            catch (SensorNullableException)
            {
                return new JsonResult(new
                {
                    value = "NaN",
                    isOnline = false,
                    timeInMinute = 0,
                    timeInSecond = 0,
                });
            }

            var sensorTimeStamp = DateTime.Parse(sensor.TimeStamp);

            return new JsonResult(new
            {
                value = sensor.ValueCurrent,
                isOnline = sensor.IsOnline,
                timeInMinute = sensorTimeStamp.Minute,
                timeInSecond = sensorTimeStamp.Second,
            });
        }
    }
}
