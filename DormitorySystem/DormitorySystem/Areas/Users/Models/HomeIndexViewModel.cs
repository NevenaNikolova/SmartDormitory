using DormitorySystem.Data.Models;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(UserSensor userSensors)
        {
            this.Name = userSensors.Name;
            this.Description = userSensors.SampleSensor.Description;
            this.CurrentValue =
                userSensors.SampleSensor.ValueCurrent.ToString()
                + " " + userSensors.SampleSensor.Measure.MeasureType.ToString();
            this.Accesslevel = userSensors.IsPrivate;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CurrentValue { get; set; }

        public bool Accesslevel { get; set; }
    }
}
