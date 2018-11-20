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
        public double Value { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public ICollection<UserSensor> UserSensors { get; set; }
    }
}
