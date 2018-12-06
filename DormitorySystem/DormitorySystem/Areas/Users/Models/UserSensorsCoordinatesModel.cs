using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class UserSensorsCoordinatesModel
    {
        public UserSensorsCoordinatesModel(UserSensor model)
        {
            Name = model.Name;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }

        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
