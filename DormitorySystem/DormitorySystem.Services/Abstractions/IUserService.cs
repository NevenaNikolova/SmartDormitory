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

        UserSensor RegisterSensor(string userId);
        UserSensor EditSensor(string userId);
        IEnumerable<UserSensor> ListSensors(string userId = "all");

        User AssignRoles(string userId);

    }
}
