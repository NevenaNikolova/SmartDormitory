using DormitorySystem.Data.Context;
using DormitorySystem.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> CheckForOutOfRangeSensorsAsync()
        {
            int count = 0;
            var listOfSampleSensors = this.context.SampleSensors.ToList();

            foreach (var sampleSensor in listOfSampleSensors)
            {
                if (sampleSensor.IsOnline)
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
                            count++;
                        }
                    }
                }
                else
                {
                    await hubService.NotifyToAll("Sensor is offline");
                    return count;
                }
            }
            return count;
        }
    }
}
