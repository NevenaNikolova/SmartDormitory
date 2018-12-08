using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Users.Models.AbstractModels;
using System;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class RegisterSensorModel : BaseRegisterEditViewModel
    {

        public RegisterSensorModel()
        {
        }

        public RegisterSensorModel(SampleSensor sampleSensor, string userId)
        {
            this.SampleSensorId = sampleSensor.Id;
            this.UserId = userId;
            this.Tag = sampleSensor.Tag;
            this.Description = sampleSensor.Description;
            this.MeasureType = sampleSensor.Measure.MeasureType;
            this.MinPollingInterval = sampleSensor.MinPollingInterval;
            this.UserPollingInterval = this.MinPollingInterval;
            this.MinValue = sampleSensor.MinValue;
            this.MaxValue = sampleSensor.MaxValue;
            this.UserMinValue = this.MinValue;
            this.UserMaxValue = this.MaxValue;

        }

        public RegisterSensorModel(UserSensor model) : base(model)
        {
            MeasureType = model.SampleSensor.Measure.MeasureType;
            Tag = model.SampleSensor.Tag;
            Description = model.SampleSensor.Description;
        }

        public string MeasureType { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
    }
}
