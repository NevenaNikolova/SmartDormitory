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

        }
        public int UserPollingInterval { get; set; }
        public int MinPollingInterval { get; set; }
        public double? UserMinValue { get; set; }
        public double? MinValue { get; set; }
        public double? UserMaxValue { get; set; }
        public double? MaxValue { get; set; }

        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }

        public bool SendNotification { get; set; }
        public Guid SampleSensorId { get; set; }
        public string UserId { get; set; }
    }
}
