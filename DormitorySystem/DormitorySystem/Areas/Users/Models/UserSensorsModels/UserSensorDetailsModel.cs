using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class UserSensorDetailsModel:BaseUserSensorViewModel
    {
        public UserSensorDetailsModel(UserSensor model):base(model)
        {           
            UserPollingInterval = model.PollingInterval;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            SendNotification = model.SendNotification;
        }
       
        public int UserPollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
    }
}
