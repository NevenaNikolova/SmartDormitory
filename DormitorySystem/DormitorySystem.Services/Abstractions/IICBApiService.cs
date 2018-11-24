using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DormitorySystem.Services.Abstractions
{
    public interface IICBApiService
    {
        IDictionary<string, SampleSensor> InitialSensorLoad();
        string CheckForNewSensor();
        IDictionary<string, SampleSensor> UpdateSensors(IDictionary<string, SampleSensor> listOfSensors);
    }
}
