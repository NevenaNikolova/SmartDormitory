using DormitorySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface INotificationsService
    {
        Task CheckForOutOfRangeSensorsAsync(IDictionary<string, SampleSensor> listOfSensors);
    }
}