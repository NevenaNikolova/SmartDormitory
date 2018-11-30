using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUserSensorService
    {
        UserSensor GetSensor(Guid id);
        UserSensor EditSensor(Guid id, string name, int pollingInterval, 
            string latitude, string longitude, bool sendNotification, bool isPrivate);
        IEnumerable<UserSensor> GetPublicSensors();
        IEnumerable<SampleSensor> ListSampleSensors();
        IDictionary<string, IEnumerable<SampleSensor>> GetSensorsByType();
        SampleSensor GetSampleSensor(Guid id);
    }
}
