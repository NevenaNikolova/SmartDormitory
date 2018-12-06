﻿using System;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Web.Models.SensorViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DormitorySystem.Controllers
{
    [Route("api/[controller]")]
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
        public double Get()
        {
            var sensor = this.sensorsService
                .GetSampleSensor(Guid.Parse("81A2E1B1-EA5D-4356-8266-B6B42471653E"));
            var model = new SensorInformationViewModel(sensor);

            return model.Value;
        }
    }
}