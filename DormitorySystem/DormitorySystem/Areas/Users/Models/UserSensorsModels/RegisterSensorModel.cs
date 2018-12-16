using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Users.Models.AbstractModels;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class RegisterSensorModel : BaseRegisterEditViewModel
    {

        public RegisterSensorModel()
        {
        }

        public RegisterSensorModel(SampleSensor sampleSensor, string userId)
        {
            base.SampleSensorId = sampleSensor.Id;
            base.UserId = userId;
            this.Tag = sampleSensor.Tag;
            this.Description = sampleSensor.Description;
            base.MeasureType = sampleSensor.Measure.MeasureType;
            base.MinPollingInterval = sampleSensor.MinPollingInterval;
            base.UserPollingInterval = base.MinPollingInterval;
            base.MinValue = sampleSensor.MinValue;
            base.MaxValue = sampleSensor.MaxValue;
            base.UserMinValue = base.MinValue;
            base.UserMaxValue = base.MaxValue;
        }

        public RegisterSensorModel(UserSensor model) : base(model)
        {
            this.Tag = model.SampleSensor.Tag;
            this.Description = model.SampleSensor.Description;
        }

        public string Tag { get; set; }
        public string Description { get; set; }
    }
}
