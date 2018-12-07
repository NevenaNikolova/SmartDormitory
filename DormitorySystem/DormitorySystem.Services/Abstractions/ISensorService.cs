using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface ISensorsService
    {
        UserSensor GetUserSensor(Guid id);

        UserSensor RegisterSensor(UserSensor newSensor);

        UserSensor EditSensor(UserSensor editedSensor);

        IEnumerable<UserSensor> GetPublicSensors();

        IEnumerable<SampleSensor> ListSampleSensors();

        IEnumerable<UserSensor> ListSensors(string userId = "all");

        SampleSensor GetSampleSensor(Guid id);
    }
}
