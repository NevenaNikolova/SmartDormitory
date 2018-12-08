using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System;

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
        }

        public Guid SampleSensorId { get; set; }
        public int UserPollingInterval { get; set; }
        public double? UserMinValue { get; set; }
        public double? UserMaxValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
        public string MeasureType { get; set; }
    }
}
