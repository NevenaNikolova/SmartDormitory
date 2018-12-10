using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class UserIndexModel : BaseUserSensorViewModel
    {
        public UserIndexModel(UserSensor model) : base(model)
        {
            this.Description = model.SampleSensor.Description;

            this.CurrentValue =
                model.SampleSensor.ValueCurrent.ToString()
                + " " + model.SampleSensor.Measure.MeasureType.ToString();

            this.SensorType = model.SampleSensor.SensorType.Name;
            this.IsPrivate = model.IsPrivate;
            this.IsOnline = model.SampleSensor.IsOnline;
        }
        [Display(Name="Sensor Type")]
        public string SensorType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Current Value")]
        public string CurrentValue { get; set; }

        [Display(Name = "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }

        public bool IsOnline { get; set; }
    }
}
