using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Data.Models
{
    public class SampleSensor
    {
        public Guid Id { get; set; }

        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingInterval { get; set; }

        public int MeasureId { get; set; }
        public Measure Measure { get; set; }

        public string TimeStamp { get; set; }
        public double ValueCurrent { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public int SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }

        public bool isOnline { get; set; }

        public ICollection<UserSensor> UserSensors { get; set; }
    }
}
