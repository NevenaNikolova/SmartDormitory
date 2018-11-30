using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Models.SensorViewModels
{
    public class UserSensorViewModel
    {
        public UserSensorViewModel()
        {
                
        }
        public UserSensorViewModel(UserSensor userSensor)
        {
            Id = userSensor.Id;
            SampleSensorId = userSensor.SampleSensorId;
            SensorType = userSensor.SampleSensor.SensorType;
            SampleSensor = userSensor.SampleSensor;
            User = userSensor.User;
            Name = userSensor.Name;
            PollingInterval = userSensor.PollingInterval;
            Latitude = userSensor.Latitude;
            Longitude = userSensor.Longitude;
            SendNotification = userSensor.SendNotification;
            IsPrivate = userSensor.IsPrivate;
        }

        [Required]
        public Guid Id { get; set; }
       
        [Required]
        public Guid SampleSensorId { get; set; }

        public SampleSensor SampleSensor { get; set; }
     
        public SensorType SensorType { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
     
        [Required]
    
        public int PollingInterval { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public bool SendNotification { get; set; }

        [Required]
        public bool IsPrivate { get; set; }
    }
}
