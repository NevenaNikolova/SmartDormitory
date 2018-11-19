using System;

namespace DormitorySystem.Data.Models
{
    public class Sensor
    {
        public Guid Id { get; set; }


        public int TypeId { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }
        public int PollingInterval { get; set; }
        public int Value { get; set; }

    }
}