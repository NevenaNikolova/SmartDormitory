using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class SensorInformationViewModel
    {
        public SensorInformationViewModel(SampleSensor sampleSensor)
        {
            this.Value = sampleSensor.ValueCurrent;
            this.PollingInterval = sampleSensor.MinPollingInterval;
            this.Measure = sampleSensor.Measure.MeasureType;
        }

        public int PollingInterval { get; set; }
        public double Value { get; set; }
        public string Measure { get; set; }
    }
}
