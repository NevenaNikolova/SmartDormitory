using DormitorySystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Models.SensorViewModels
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
        [Display(Name="Name")]
        public string Name { get; set; }

        public Guid SampleSensorId { get; set; }
        public SampleSensor SampleSensor { get; set; }

        public SensorType SensorType { get; set; }

        [Required]
        [Display(Name="Update Sensor Interval in Seconds")]
        public int UserPollingInterval { get; set; }
        public int MinPollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Display(Name="Send Email if Sensor Values are Out of Range")]
        public bool SendNotification { get; set; }
        [Display(Name="This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }
    }
}