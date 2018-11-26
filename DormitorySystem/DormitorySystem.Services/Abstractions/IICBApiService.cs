using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services.Abstractions
{
    public interface IICBApiService
    {
        IDictionary<string, SampleSensor> InitialSensorLoad();

        IDictionary<string, SampleSensor> CheckForNewSensor
            (IDictionary<string, SampleSensor> listOfSensors);

        IDictionary<string, SampleSensor> UpdateSensors
            (IDictionary<string, SampleSensor> listOfSensors);
    }
}
