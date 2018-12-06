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

        public UserSensorViewModel(SampleSensor sampleSensor, string userId)
        {
            this.UserId = userId;
            this.LoadSampleSensorData(sampleSensor);
        }

        public UserSensorViewModel(UserSensor model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.LoadSampleSensorData(model.SampleSensor);
            this.UserPollingInterval = model.PollingInterval;
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
            this.SendNotification = model.SendNotification;
            this.IsPrivate = model.IsPrivate;
            this.UserId = model.UserId;
            this.UserEmail = model.User.Email;
            this.CreatedOn = model.CreatedOn;
            this.ModifiedOn = model.ModifiedOn;
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} must be at list {2} and at max {1} characters long")]
        public string Name { get; set; }

        public Guid SampleSensorId { get; set; }

        public string SensorType { get; set; }

        public string MeasureType { get; set; }

        public string SempleSensorTag { get; set; }

        public string SampleSensorDescription { get; set; }

        [Display(Name = "Minimal update Sensor interval in Seconds")]
        public int UserPollingInterval { get; set; }

        public int MinPollingInterval { get; set; }

        public double? MinValue { get; set; }

        [Display(Name = "Acceptable minimal value")]
        public double UserMinValue { get; set; }

        public double? MaxValue { get; set; }

        [Display(Name = "Acceptable maximum value")]
        public double UserMaxValue { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [Display(Name = "Send Email if Sensor Values are Out of Range")]
        public bool SendNotification { get; set; }

        [Display(Name = "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreatedOn { get; }

        public DateTime? ModifiedOn { get; }

        private string LoadSampleSensorData(SampleSensor sampleSensor)
        {
            this.SampleSensorId = sampleSensor.Id;
            this.SensorType = sampleSensor.SensorType.Name;
            this.MinPollingInterval = sampleSensor.MinPollingInterval;
            this.UserMinValue = sampleSensor.MinValue ?? 0;
            this.UserMaxValue = sampleSensor.MaxValue ?? 0;
            this.MinValue = sampleSensor.MinValue;
            this.MaxValue = sampleSensor.MaxValue;
            this.SempleSensorTag = sampleSensor.Tag;
            this.SampleSensorDescription = sampleSensor.Description;
            this.MeasureType = sampleSensor.Measure.MeasureType;

            return "Initialization of internal properties was completed";
        }
    }
}