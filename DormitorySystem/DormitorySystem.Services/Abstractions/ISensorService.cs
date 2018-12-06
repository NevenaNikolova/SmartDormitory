using DormitorySystem.Data.Models;
using DormitorySystem.Services.ServiceModels;
using System;
using System.Collections.Generic;

namespace DormitorySystem.Services.Abstractions
{
    public interface ISensorsService
    {
        UserSensor GetUserSensor(Guid id);

        UserSensor RegisterSensor(ServiceSensorModel registrationData);

        UserSensor EditSensor(ServiceSensorModel editData);

        IEnumerable<UserSensor> GetPublicSensors();

        IEnumerable<SampleSensor> ListSampleSensors();

        IEnumerable<UserSensor> ListSensors(string userId = "all");

        SampleSensor GetSampleSensor(Guid id);
    }
}
