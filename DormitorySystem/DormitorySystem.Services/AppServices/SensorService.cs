using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DormitorySystem.Services.AppServices
{
    public class SensorService : ISensorsService
    {
        private readonly DormitorySystemContext context;

        public SensorService(DormitorySystemContext context)
        {
            this.context = context;
        }

        public SampleSensor GetSampleSensor(Guid sampleSensorId)
        {
            var sensor = this.context.SampleSensors
                .Include(s => s.SensorType)
                .Include(s => s.Measure)
                .SingleOrDefault(s => s.Id == sampleSensorId);

            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            return sensor;
        }

        public IEnumerable<SampleSensor> ListSampleSensors()
        {
            var sampleSensors = this.context.SampleSensors
                .Include(s => s.SensorType)
                .Include(s => s.Measure)
                .ToList();

            if (sampleSensors == null)
            {
                throw new SensorNullableException("There is no such sensors.");
            }

            return sampleSensors;
        }

        public IEnumerable<UserSensor> ListSensors(string userId = "all")
        {
            IQueryable<UserSensor> allSensors = this.context.UserSensors
                    .Include(us => us.SampleSensor)
                    .Include(s => s.SampleSensor.SensorType)
                    .Include(s => s.SampleSensor.Measure)
                    .Include(us => us.User);

            if (userId != "all")
            {
                allSensors = allSensors.Where(id => id.UserId == userId);
            }

            return allSensors;
        }

        public IEnumerable<UserSensor> GetPublicSensors()
        {
            var sensors = this.context.UserSensors
                .Where(s => s.IsPrivate == false)
                .Include(us => us.User)
                .Include(us => us.SampleSensor)
                .ToList();

            if (sensors == null)
            {
                throw new SensorNullableException("There is no such sensors.");
            }

            return sensors;
        }

        public UserSensor GetUserSensor(Guid userSensorId)
        {
            var sensor = this.context.UserSensors
                .Include(us => us.User)
                .Include(us => us.SampleSensor.SensorType)
                .Include(us => us.SampleSensor.Measure)
                 .SingleOrDefault(s => s.Id == userSensorId);
            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            return sensor;
        }

        public UserSensor RegisterSensor(UserSensor newSensor)
        {
            this.context.UserSensors.Add(newSensor);
            this.context.SaveChanges();

            return newSensor;
        }

        public UserSensor EditSensor(UserSensor editedSensor)
        {
            this.context.Update(editedSensor);
            this.context.SaveChanges();
            return editedSensor;
        }
    }
}
