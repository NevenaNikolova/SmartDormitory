using DormitorySystem.Data.Models.Abstractions;
using System;
using Utilities;

namespace DormitorySystem.Data.Models
{
    public class UserSensor:DataModel
    {
        public Guid Id { get; set; }

        public Guid SampleSensorId { get; set; }
        public SampleSensor SampleSensor { get; set; }

        public string Name { get; set; }
        public int PollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
    }
}