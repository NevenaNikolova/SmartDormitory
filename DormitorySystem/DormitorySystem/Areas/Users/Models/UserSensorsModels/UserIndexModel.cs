using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class UserIndexModel : BaseUserSensorViewModel
    {
        public UserIndexModel(UserSensor model) : base(model)
        {
            this.Description = model.SampleSensor.Description;

            //this.can't work for bool
            this.CurrentValue =
                model.SampleSensor.ValueCurrent.ToString()
                + " " + model.SampleSensor.Measure.MeasureType.ToString();

            this.SensorType = model.SampleSensor.SensorType.Name;
        }
        public string SensorType { get; set; }
        public string Description { get; set; }
        public string CurrentValue { get; set; }
    }
}
