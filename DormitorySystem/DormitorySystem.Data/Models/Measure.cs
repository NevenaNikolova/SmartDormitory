using System.Collections.Generic;

namespace DormitorySystem.Data.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string MeasureType { get; set; }
        public ICollection<SampleSensor>SampleSensors{ get; set; }
    }
}