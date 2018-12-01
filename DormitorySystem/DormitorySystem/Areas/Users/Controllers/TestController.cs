using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Areas.Users.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Web.Areas.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController
    {
        private readonly IUserSensorService userSensorService;

        public TestController(IUserSensorService userSensorService)
        {
            this.userSensorService = userSensorService;
        }
        
        // GET: api/Test
        [HttpGet]
        public double Get()
        {
            var sensor = this.userSensorService
                .GetSampleSensor(Guid.Parse("81A2E1B1-EA5D-4356-8266-B6B42471653E"));
            var model = new SensorInformationViewModel(sensor);

            return model.Value;
        }
    }
}
