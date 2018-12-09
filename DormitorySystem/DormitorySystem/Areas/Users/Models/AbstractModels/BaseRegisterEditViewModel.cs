using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DormitorySystem.Data.Models;

namespace DormitorySystem.Web.Areas.Users.Models.AbstractModels
{
    public class BaseRegisterEditViewModel : BaseUserSensorViewModel
    {
        public BaseRegisterEditViewModel()
        {
        }

        public BaseRegisterEditViewModel(UserSensor model) : base(model)
        {
            UserPollingInterval = model.PollingInterval;
            MinPollingInterval = model.SampleSensor.MinPollingInterval;
            UserMinValue = model.UserMinValue;
            MinValue = model.SampleSensor.MinValue;
            UserMaxValue = model.UserMaxValue;
            MaxValue = model.SampleSensor.MaxValue;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            SendNotification = model.SendNotification;          
            SampleSensorId = model.SampleSensorId;
            UserId = model.UserId;
            MeasureType = model.SampleSensor.Measure.MeasureType;

        }
        [Display(Name ="Update Interval in Seconds")]
        public int UserPollingInterval { get; set; }

        public int MinPollingInterval { get; set; }

        [Display(Name ="Custom Min Value")]
        public double? UserMinValue { get; set; }

        public double? MinValue { get; set; }

        [Display(Name="Custom Max Value")]
        public double? UserMaxValue { get; set; }

        public double? MaxValue { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Display(Name ="Values Out of Range Alert")]
        public bool SendNotification { get; set; }

        public Guid SampleSensorId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Measure")]
        public string MeasureType { get; set; }
    }
}
