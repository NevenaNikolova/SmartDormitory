﻿using DormitorySystem.Common.Exceptions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Services.AppServices
{
    public class SensorService : ISensorsService
    {
        private readonly DormitorySystemContext context;

        public SensorService(DormitorySystemContext context)
        {
            this.context = context;
        }

        public async Task<SampleSensor> GetSampleSensorAsync(Guid sampleSensorId)
        {
            var sensor = await this.context.SampleSensors
                .Include(s => s.SensorType).Include(s => s.Measure)
                .SingleOrDefaultAsync(s => s.Id == sampleSensorId)
                ?? throw new SensorNullableException("This sensor was not found.");

            return sensor;
        }

        public async Task<IEnumerable<SampleSensor>> ListSampleSensorsAsync()
        {
            var sampleSensors = await this.context.SampleSensors
                .Include(s => s.SensorType).Include(s => s.Measure)
                .ToListAsync()
                ?? throw new SensorNullableException("These sensors were not found.");

            return sampleSensors;
        }

        public async Task<IEnumerable<UserSensor>> ListSensorsAsync(string userId = "all")
        {
            IQueryable<UserSensor> allSensors = this.context.UserSensors
                    .Include(us => us.SampleSensor).Include(s => s.SampleSensor.SensorType)
                    .Include(s => s.SampleSensor.Measure).Include(us => us.User);

            if (userId != "all")
            {
                allSensors = allSensors.Where(us => us.UserId == userId && !us.isDeleted);
            }

            return await allSensors.ToListAsync();
        }

        public async Task<IEnumerable<UserSensor>> GetPublicSensorsAsync()
        {
            var sensors = await this.context.UserSensors
                .Where(s => !s.IsPrivate && !s.isDeleted)
                .Include(us => us.User).Include(us => us.SampleSensor)
                .ToListAsync();

            return sensors;
        }

        public async Task<UserSensor> GetUserSensorAsync(Guid userSensorId)
        {
            var sensor = await this.context.UserSensors
                .Include(us => us.User).Include(us => us.SampleSensor.SensorType)
                .Include(us => us.SampleSensor.Measure)
                .SingleOrDefaultAsync(s => s.Id == userSensorId && !s.isDeleted)
                ?? throw new SensorNullableException("This sensor was not found.");

            return sensor;
        }
        public async Task<UserSensor> DeleteUserSensorAsync(Guid userSensorId)
        {
            var sensor = await this.context.UserSensors
                .SingleOrDefaultAsync(s => s.Id == userSensorId)
                ?? throw new SensorNullableException("This sensor was not found.");

            sensor.isDeleted = true;
            sensor.DeletedOn = DateTime.Now;
            await this.context.SaveChangesAsync();
            return sensor;
        }
        public async Task<UserSensor> RegisterSensorAsync(UserSensor newSensor)
        {
            if (newSensor == null)
            {
                throw new SensorNullableException("There is no sensor for registration.");
            }

            await this.context.UserSensors.AddAsync(newSensor);
            await this.context.SaveChangesAsync();

            return newSensor;
        }

        public async Task<UserSensor> EditSensorAsync(UserSensor editedSensor)
        {
            if (editedSensor == null)
            {
                throw new SensorNullableException("There is no sensor for update.");
            }

            this.context.Update(editedSensor);
            editedSensor.ModifiedOn = DateTime.Now;

            await this.context.SaveChangesAsync();
            return editedSensor;
        }
    }
}
