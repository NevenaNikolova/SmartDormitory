using DormitorySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface IICBApiService
    {
        IDictionary<string, SampleSensor> InitialSensorLoad();

        Task<IDictionary<string, SampleSensor>> CheckForNewSensor
              (IDictionary<string, SampleSensor> listOfSensors);

        Task<IDictionary<string, SampleSensor>> UpdateSensors
             (IDictionary<string, SampleSensor> listOfSensors);
    }
}
