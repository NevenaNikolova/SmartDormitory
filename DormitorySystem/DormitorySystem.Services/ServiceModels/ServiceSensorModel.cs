using System;

namespace DormitorySystem.Services.ServiceModels
{
    public class ServiceSensorModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public Guid SampleSensorId { get; set; }
        public int UserPollingInterval { get; set; }
        public double UserMinValue { get; set; }
        public double UserMaxValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
    }
}
