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
            this.Id = model.Id;
            this.Name = model.Name;
            this.SampleSensor = model.SampleSensor;
            this.SampleSensorId = model.SampleSensorId;
            this.SensorType = model.SampleSensor.SensorType;
            this.UserPollingInterval = model.PollingInterval;
            this.MinPollingInterval = model.SampleSensor.MinPollingInterval;
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
            this.SendNotification = model.SendNotification;
            this.IsPrivate = model.IsPrivate;
            this.User = model.User;
            this.CreatedOn = model.CreatedOn;
            this.ModifiedOn = model.ModifiedOn;
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public Guid SampleSensorId { get; set; }
        public SampleSensor SampleSensor { get; set; }

        public SensorType SensorType { get; set; }

        [Required]
        [Display(Name = "Update Sensor Interval in Seconds")]
        public int UserPollingInterval { get; set; }

        public int MinPollingInterval { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [Display(Name = "Send Email if Sensor Values are Out of Range")]
        public bool SendNotification { get; set; }

        [Display(Name = "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; }

        public DateTime? ModifiedOn { get; }
    }
}

