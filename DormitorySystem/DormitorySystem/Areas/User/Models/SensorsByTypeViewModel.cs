using DormitorySystem.Data.Models;
using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.User.Models
{
    public class SensorsByTypeViewModel
    {
        public SensorsByTypeViewModel(IDictionary<string, IEnumerable<SampleSensor>> sensors)
        {
            this.SampleSensorsByType = sensors;
        }

        public IDictionary<string, IEnumerable<SampleSensor>> SampleSensorsByType { get; set; }

    }
}
