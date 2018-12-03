using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface ISensorsService
    {
        UserSensor GetUserSensor(Guid id);

        UserSensor RegisterSensor(string userId, Guid sampleSensorId, string name,
            int pollingInterval, string latitude, string longitude,
            bool sendNotification, bool isPrivate);

        UserSensor EditSensor(Guid id, string name, int pollingInterval, 
            string latitude, string longitude, bool sendNotification, bool isPrivate);

        IEnumerable<UserSensor> GetPublicSensors();

        IEnumerable<SampleSensor> ListSampleSensors();

        IEnumerable<UserSensor> ListSensors(string userId = "all");

        SampleSensor GetSampleSensor(Guid id);
    }
}
