﻿using DormitorySystem.Data.Models;

namespace DormitorySystem.Web.Models.SensorsViewModels
{
    public class SensorInformationModel
    {
        public SensorInformationModel(SampleSensor sampleSensor)
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
