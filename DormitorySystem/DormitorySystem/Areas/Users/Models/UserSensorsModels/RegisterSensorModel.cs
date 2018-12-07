using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class RegisterSensorModel
    {
        public RegisterSensorModel()
        {
        }

        public RegisterSensorModel(SampleSensor model, string userId)
        {
            UserId = userId;

            SampleSensorId = model.Id;
            MinPollingInterval = model.MinPollingInterval;
            MinValue = model.MinValue;
            MaxValue = model.MaxValue;
            MeasureType = model.Measure.MeasureType;
            Tag = model.Tag;
            Description = model.Description;
        }

        public RegisterSensorModel(UserSensor model)
        {
            Id =model.Id;
            Name = model.Name;
            UserPollingInterval = model.PollingInterval;
            MinPollingInterval = model.SampleSensor.MinPollingInterval;
            UserMinValue =  model.UserMinValue ?? 0;
            MinValue = model.SampleSensor.MinValue;
            UserMaxValue =model.UserMaxValue??0;
            MaxValue = model.SampleSensor.MaxValue;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            SendNotification = model.SendNotification;
            IsPrivate = model.IsPrivate;
            SampleSensorId = model.SampleSensorId;

            UserId = model.UserId;
            MeasureType = model.SampleSensor.Measure.MeasureType;
            Tag = model.SampleSensor.Tag;
            Description = model.SampleSensor.Description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UserPollingInterval { get; set; }
        public int MinPollingInterval { get; set; }
        public double UserMinValue { get; set; }
        public double? MinValue { get; set; }
        public double UserMaxValue { get; set; }
        public double? MaxValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
        public Guid SampleSensorId { get; set; }       
        public string UserId { get; set; }

        public string MeasureType { get; set; }
        public SampleSensor SampleSensor { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
    }
}
