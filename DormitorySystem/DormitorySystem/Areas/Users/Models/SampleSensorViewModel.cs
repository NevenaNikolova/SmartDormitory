using DormitorySystem.Data.Models;
using System;

namespace DormitorySystem.Web.Areas.Users.Models
{
    public class SampleSensorViewModel
    {
            public SampleSensorViewModel()
            {
            }

            public SampleSensorViewModel(SampleSensor sampleSensor)
            {
                Id = sampleSensor.Id;
                Tag = sampleSensor.Tag;
                Description = sampleSensor.Description;
                MinPollingInterval = sampleSensor.MinPollingInterval;
                Measure = sampleSensor.Measure;
                ValueCurrent = sampleSensor.ValueCurrent;
                MinValue = sampleSensor.MinValue;
                MaxValue = sampleSensor.MaxValue;
                Type = sampleSensor.SensorType;
              //  UserSensors = sampleSensor.UserSensors;
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

