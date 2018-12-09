using DormitorySystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Minimum Update Interval in Seconds")]
        public int MinPollingInterval { get; set; }

        public Measure Measure { get; set; }

        [Display(Name ="Current Value")]
        public double ValueCurrent { get; set; }

        [Display(Name ="Min Value")]
        public double? MinValue { get; set; }

        [Display(Name ="Max Value")]
        public double? MaxValue { get; set; }

        public SensorType Type { get; set; }
    }
}

