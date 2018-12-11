using DormitorySystem.Data.Models;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface INotificationsService
    {
        void CheckForOutOfRangeSensors(IEnumerable<SampleSensor> sampleSensors);
    }
}