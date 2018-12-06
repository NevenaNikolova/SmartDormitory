using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using DormitorySystem.Services.ServiceModels;
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

        public SampleSensor GetSampleSensor(Guid id)
        {
            var sensor = this.context.SampleSensors
                .Include(s => s.SensorType)
                .Include(s => s.Measure)
                .SingleOrDefault(s => s.Id == id);

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
                .Include(us => us.SampleSensor)
                .Include(us => us.SampleSensor.SensorType)
                 .SingleOrDefault(s => s.Id == userSensorId);
            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            return sensor;
        }

        public UserSensor RegisterSensor(ServiceSensorModel registrationData)
        {
            var newSensor = ConvertServiceSensorModelToUserSensor(registrationData, new UserSensor());

            this.context.UserSensors.Add(newSensor);
            this.context.SaveChanges();

            return newSensor;
        }

        public UserSensor EditSensor(ServiceSensorModel editData)
        {
            var sensor = this.context.UserSensors
                .Include(s => s.SampleSensor)
                .SingleOrDefault(s => s.Id == editData.UserSensorId);

            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            sensor = ConvertServiceSensorModelToUserSensor(editData, sensor);

            this.context.SaveChanges();
            return sensor;
        }

        private UserSensor ConvertServiceSensorModelToUserSensor
            (ServiceSensorModel serviceSensorModel, UserSensor userSensor)
        {
            userSensor.Id = serviceSensorModel.UserSensorId;
            userSensor.Name = serviceSensorModel.Name;
            userSensor.UserId = serviceSensorModel.UserId;
            userSensor.SampleSensorId = serviceSensorModel.SampleSensorId;
            userSensor.PollingInterval = serviceSensorModel.UserPollingInterval;
            userSensor.UserMinValue = serviceSensorModel.UserMinValue;
            userSensor.UserMaxValue = serviceSensorModel.UserMaxValue;
            userSensor.Latitude = serviceSensorModel.Latitude;
            userSensor.Longitude = serviceSensorModel.Longitude;
            userSensor.SendNotification = serviceSensorModel.SendNotification;
            userSensor.IsPrivate = serviceSensorModel.IsPrivate;

            return userSensor;
        }
    }
}
