using System.Collections.Generic;

namespace DormitorySystem.Data.Models
{
    public class SensorType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SampleSensor> SampleSensors { get; set; }
    }
}