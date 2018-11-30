using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(UserSensor userSensors)
        {
            this.Id = userSensors.Id;
            this.Name = userSensors.Name;
            this.Description = userSensors.SampleSensor.Description;
            this.CurrentValue =
                userSensors.SampleSensor.ValueCurrent.ToString()
                + " " + userSensors.SampleSensor.Measure.MeasureType.ToString();
            this.Accesslevel = userSensors.IsPrivate;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CurrentValue { get; set; }

        public bool Accesslevel { get; set; }
    }
}
