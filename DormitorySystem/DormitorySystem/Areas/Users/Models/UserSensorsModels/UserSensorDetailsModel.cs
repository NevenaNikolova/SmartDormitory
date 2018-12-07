using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class UserSensorDetailsModel
    {
        public UserSensorDetailsModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            UserPollingInterval = model.PollingInterval;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            SendNotification = model.SendNotification;
            IsPrivate = model.IsPrivate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UserPollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
    }
}
