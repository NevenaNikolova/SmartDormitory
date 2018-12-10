using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface ISensorsService
    {
        Task<UserSensor> GetUserSensorAsync(Guid id);

        Task<UserSensor> RegisterSensorAsync(UserSensor newSensor);

        Task<UserSensor> EditSensorAsync(UserSensor editedSensor);

        Task<IEnumerable<UserSensor>> GetPublicSensorsAsync();

        Task<IEnumerable<SampleSensor>> ListSampleSensorsAsync();

        Task<IEnumerable<UserSensor>> ListSensorsAsync(string userId = "all");

        Task<SampleSensor> GetSampleSensorAsync(Guid id);

        Task<UserSensor> DeleteUserSensorAsync(Guid userSensorId);
    }
}
