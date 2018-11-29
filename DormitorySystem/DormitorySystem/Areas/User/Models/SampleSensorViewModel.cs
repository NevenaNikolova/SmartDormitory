using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.User.Models
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
                MeasureId = sampleSensor.MeasureId;
                Measure = sampleSensor.Measure;
                TimeStamp = sampleSensor.TimeStamp;
                ValueCurrent = sampleSensor.ValueCurrent;
                MinValue = sampleSensor.MinValue;
                MaxValue = sampleSensor.MaxValue;
                TypeId = sampleSensor.SensorTypeId;
                Type = sampleSensor.SensorType;
                UserSensors = sampleSensor.UserSensors;
            }

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

            public int TypeId { get; set; }
            public SensorType Type { get; set; }

            public ICollection<UserSensor> UserSensors { get; set; }
        }
    }

