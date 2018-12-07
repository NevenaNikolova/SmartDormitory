using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models.SampleSensorsModels
{
    public class SampleSensorViewModel
    {
        public SampleSensorViewModel()
        {
        }

        public SampleSensorViewModel(SampleSensor sampleSensor)
        {
            this.Id = sampleSensor.Id;
            this.Tag = sampleSensor.Tag;
            this.Description = sampleSensor.Description;
            this.MinPollingInterval = sampleSensor.MinPollingInterval;
            this.Measure = sampleSensor.Measure;
            this.ValueCurrent = sampleSensor.ValueCurrent;
            this.MinValue = sampleSensor.MinValue;
            this.MaxValue = sampleSensor.MaxValue;
            this.Type = sampleSensor.SensorType;
        }

        public Guid Id { get; set; }

        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingInterval { get; set; }

        public Measure Measure { get; set; }

        public double ValueCurrent { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public SensorType Type { get; set; }
    }
}

