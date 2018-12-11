using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class UserSensorDetailsModel : BaseUserSensorViewModel
    {
        public UserSensorDetailsModel(UserSensor model) : base(model)
        {
            this.UserPollingInterval = model.PollingInterval;
            this.UserMinValue = model.UserMinValue;
            this.UserMaxValue = model.UserMaxValue;
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
            this.SendNotification = model.SendNotification;
            this.IsPrivate = model.IsPrivate;
            this.MeasureType = model.SampleSensor.Measure.MeasureType;
            this.SampleSensorId = model.SampleSensorId;
            this.IsDeleted = model.isDeleted;
            this.TimeStamp = DateTime.Parse(model.SampleSensor.TimeStamp);
        }

        public Guid SampleSensorId { get; set; }

        [Display(Name = "Update Interval in Seconds")]
        public int UserPollingInterval { get; set; }

        [Display(Name = "Custom Min Value")]
        public double? UserMinValue { get; set; }

        [Display(Name = "Custom Max Value")]
        public double? UserMaxValue { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Display(Name = "Values Out of Range Alert")]
        public bool SendNotification { get; set; }

        [Display(Name = "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }

        [Display(Name = "Measure")]
        public string MeasureType { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
