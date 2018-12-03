using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DormitorySystem.Services.AppServices
{
    public class UserService : IUsersService
    {
        private readonly DormitorySystemContext contex;
       
        public UserService(DormitorySystemContext contex)
        {
            this.contex = contex;        
        }

        //public UserSensor EditSensor(Guid userSensorId, string newName, int newPolling, string newLatitude,
        //    string newLongitude, bool newNotification, bool newIsPrivate)
        //{
        //    var sensor = this.contex.UserSensors
        //        .SingleOrDefault(s => s.Id == userSensorId);

        //    if (sensor == null)
        //    {
        //        throw new SensorNullableException("There is no such sensor.");
        //    }

        //    sensor.Name = newName;
        //    sensor.PollingInterval = newPolling;
        //    sensor.Latitude = newLatitude;
        //    sensor.Longitude = newLongitude;
        //    sensor.SendNotification = newNotification;
        //    sensor.IsPrivate = newIsPrivate;

        //    this.contex.SaveChanges();

        //    return sensor;
        //}

        public User GetUser(string Id)
        {
            var user = this.contex.Users
                .Include(u => u.Sensors)                                   
                        .SingleOrDefault(u => u.Id == Id);
            if (user == null)
            {
                throw new UserNullableException("There is no such user.");
            }
            return user;

        }
     
        public IEnumerable<User> ListUsers()
        {
            var users = this.contex.Users
                .Include(u => u.Sensors)                   
                        .ToList();

            return users;
        }
        
    }
}
