using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUserSensorService
    {
        UserSensor GetSensor(Guid id);
        IEnumerable<UserSensor> GetPublicSensors();
        IEnumerable<SampleSensor> ListSampleSensors();
        IDictionary<string, IEnumerable<SampleSensor>> GetSensorsByType();
        SampleSensor GetSampleSensor(Guid id);
    }
}
