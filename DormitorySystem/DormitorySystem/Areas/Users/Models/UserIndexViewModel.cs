using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class UserIndexViewModel
    {
        public UserIndexViewModel(UserSensor userSensors)
        {
            this.Id = userSensors.Id;
            this.Name = userSensors.Name;
            this.Description = userSensors.SampleSensor.Description;

            // this.can't work for bool
            this.CurrentValue =
                userSensors.SampleSensor.ValueCurrent.ToString()
                + " " + userSensors.SampleSensor.Measure.MeasureType.ToString();

            this.IsPrivate = userSensors.IsPrivate;
            this.SensorType = userSensors.SampleSensor.SensorType.Name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SensorType { get; set; }

        public string Description { get; set; }

        public string CurrentValue { get; set; }

        public bool IsPrivate { get; set; }
    }
}
