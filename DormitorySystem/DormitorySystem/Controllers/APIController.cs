using System;
using DormitorySystem.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<double> Get(Guid sensorId)
        {
            var sensor = await this.sensorsService.GetSampleSensorAsync(sensorId);

            return sensor.ValueCurrent;
        }
    }
}
