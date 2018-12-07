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

        public RegisterSensorModel(UserSensor model) : base(model)
        {
            MeasureType = model.SampleSensor.Measure.MeasureType;
            SampleSensor = model.SampleSensor;
            Tag = model.SampleSensor.Tag;
            Description = model.SampleSensor.Description;
        }

        public string MeasureType { get; set; }
        public SampleSensor SampleSensor { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
    }
}
