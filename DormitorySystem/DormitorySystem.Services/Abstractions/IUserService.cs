using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUserService
    {
        User GetUser(string Id);
        IEnumerable<User> ListUsers();

        UserSensor RegisterSensor(string userId, Guid sampleSensorId, string name,
            int pollingInterval, string latitude, string longitude,
            bool sendNotification, bool isPrivate);

        UserSensor EditSensor(Guid userSensorId, string newName, int newPolling, string newLatitude,
            string newLongitude, bool newNotification, bool newIsPrivate);

        IEnumerable<UserSensor> ListSensors(string userId = "all");

       // User AssignRoles(string userId);

    }
}
