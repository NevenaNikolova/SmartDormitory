using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class UserSensorViewModel
    {
        public UserSensorViewModel()
        {
        }

        public UserSensorViewModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            SampleSensor = model.SampleSensor;
            SampleSensorId = model.SampleSensorId;
            SensorType = model.SampleSensor.SensorType;
            UserPollingInterval = model.PollingInterval;
            MinPollingInterval = model.SampleSensor.MinPollingInterval;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            SendNotification = model.SendNotification;
            IsPrivate = model.IsPrivate;
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid SampleSensorId { get; set; }
        public SampleSensor SampleSensor { get; set; }

        public SensorType SensorType { get; set; }

        [Required]
        public int UserPollingInterval { get; set; }
        public int MinPollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
    }
}
