using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DormitorySystem.Services
{
    public class UserSensorService : IUserSensorService
    {
        private readonly DormitorySystemContext context;

        public UserSensorService(DormitorySystemContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserSensor> GetPublicSensors()
        {
            var sensors = this.context.UserSensors
                .Where(s => s.IsPrivate == false)
                .Include(us => us.User)
                    .ThenInclude(u => u.Email)
                .Include(us => us.SampleSensor)
                    .ThenInclude(ss => ss.Tag)
                .ToList();

            return sensors;
        }

        public UserSensor GetSensor(Guid id)
        {
            var sensor = this.context.UserSensors
                .Include(us => us.User)
                    .ThenInclude(u => u.Email)
                .Include(us => us.SampleSensor)
                    .ThenInclude(ss => ss.Tag)
                 .SingleOrDefault(s => s.Id == id);
            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            return sensor;
        }

        public IEnumerable<SampleSensor> GetSampleSensors()
        {
            var sensorTypes = this.context.SampleSensors
                .Include(s => s.Measure)
                .Include(s => s.Type)
                .ToList();
            return sensorTypes;
        }
    }
}
