using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services
{
    public class UserService : IUserService
    {
        public User AssignRoles(string userId)
        {
            throw new NotImplementedException();
        }

        public UserSensor EditSensor(string userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSensor> ListSensors(string userId = "all")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListUsers()
        {
            throw new NotImplementedException();
        }

        public UserSensor RegisterSensor(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
