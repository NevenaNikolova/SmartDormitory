using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUsersService
    {
        User GetUser(string Id);
        IEnumerable<User> ListUsers();

        

        //UserSensor EditSensor(Guid userSensorId, string newName, int newPolling, string newLatitude,
        //    string newLongitude, bool newNotification, bool newIsPrivate);   

       // User AssignRoles(string userId);

    }
}
