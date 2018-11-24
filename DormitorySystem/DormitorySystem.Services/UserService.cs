﻿using DormitorySystem.Data.Context;
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
    public class UserService : IUserService
    {
        private readonly DormitorySystemContext contex;
        private readonly UserSensorService userSensorService;

        public UserService(DormitorySystemContext contex, UserSensorService userSensorService)
        {
            this.contex = contex;
            this.userSensorService = userSensorService;
        }

        //public User AssignRoles(string userId)
        //{
        //    var user = GetUser(userId);
        //    if (user.)

        //}

        public UserSensor EditSensor(Guid userSensorId, string newName, int newPolling, string newLatitude,
            string newLongitude, bool newNotification, bool newIsPrivate)
        {
            var sensor = userSensorService.GetSensor(userSensorId);

            if (sensor == null)
            {
                throw new SensorNullableException("There is no such sensor.");
            }

            sensor.Name = newName;
            sensor.PollingInterval = newPolling;
            sensor.Latitude = newLatitude;
            sensor.Longitude = newLongitude;
            sensor.SendNotification = newNotification;
            sensor.IsPrivate = newIsPrivate;

            this.contex.SaveChanges();

            return sensor;
        }

        public User GetUser(string Id)
        {
            var user = this.contex.Users
                .Include(u => u.Sensors)
                    .ThenInclude(us => us.Name)                    
                        .SingleOrDefault(u => u.Id == Id);
            if (user == null)
            {
                throw new UserNullableException("There is no such user.");
            }
            return user;

        }
        //TO Beautify
        public IEnumerable<UserSensor> ListSensors(string userId = "all")
        {
            var allSensors = new List<UserSensor>();

            if (userId == "all")
            {
                allSensors = this.contex.UserSensors
                    .Include(us => us.SampleSensor)
                            .ThenInclude(ss => ss.Tag)
                    .Include(us => us.SampleSensor)
                            .ThenInclude(ss => ss.ValueCurrent)
                    .Include(us => us.User)
                            .ThenInclude(u => u.Email)
                    .ToList();
            }
            else
            {
                var user = GetUser(userId);
                allSensors = user.Sensors.ToList();
            }
            return allSensors;
        }

        public IEnumerable<User> ListUsers()
        {
            var users = this.contex.Users
                .Include(u => u.Sensors)
                    .ThenInclude(us => us.Name)
                        .ToList();

            return users;
        }

        public UserSensor RegisterSensor(string userId, SampleSensor sampleSensor, string name,
            int pollingInterval, string latitude, string longitude,
            bool sendNotification, bool isPrivate)
        {
            var user = GetUser(userId);

            var newSensor = new UserSensor()
            {
                SampleSensorId = sampleSensor.Id,
                SampleSensor = sampleSensor,
                User = user,
                Name = name,
                PollingInterval = pollingInterval,
                Latitude = latitude,
                Longitude = longitude,
                SendNotification = sendNotification,
                IsPrivate = isPrivate
            };

            user.Sensors.Add(newSensor);
            this.contex.SaveChanges();

            return newSensor;
        }
    }
}