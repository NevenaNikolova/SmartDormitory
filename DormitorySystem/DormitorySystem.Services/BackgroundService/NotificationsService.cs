using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DormitorySystem.Services.BackgroundService
{
    public class NotificationsService : INotificationsService
    {
        private readonly DormitorySystemContext context;
        private readonly IHubService hubService;

        public NotificationsService(DormitorySystemContext context, IHubService hubService)
        {
            this.context = context;
            this.hubService = hubService;
        }

        public async void CheckForOutOfRangeSensors(IEnumerable<SampleSensor> sampleSensors)
        {
            foreach (var sampleSensor in sampleSensors)
            {
                var userSensors = this.context.UserSensors
                    .Where(us => us.SampleSensorId == sampleSensor.Id).ToList();

                foreach (var userSensor in userSensors)
                {
                    if ((sampleSensor.ValueCurrent > userSensor.UserMaxValue
                        || sampleSensor.ValueCurrent < userSensor.UserMinValue)
                        && userSensor.SendNotification)
                    {
                        await hubService.Notify(userSensor.UserId, userSensor.Name);
                    }
                }
            }
        }
    }
}
