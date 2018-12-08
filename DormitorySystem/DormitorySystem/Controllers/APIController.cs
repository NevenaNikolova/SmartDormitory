using System;
using DormitorySystem.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using DormitorySystem.Web.Models.SensorsViewModels;

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
        
        // GET: api/Test
        [HttpGet]
        public double Get(Guid sensorId)
        {
            var sensor = this.sensorsService
                .GetSampleSensor(sensorId);

            return sensor.ValueCurrent;
        }
    }
}
