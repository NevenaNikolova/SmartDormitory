using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Models.SensorViewModels
{
    public class PublicSensorsCoordinates
    {
        public PublicSensorsCoordinates(UserSensor model)
        {
            Name = model.Name;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
