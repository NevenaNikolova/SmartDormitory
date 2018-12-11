using System;
using DormitorySystem.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            var sensor = await this.sensorsService.GetSampleSensorAsync(sensorId);
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
