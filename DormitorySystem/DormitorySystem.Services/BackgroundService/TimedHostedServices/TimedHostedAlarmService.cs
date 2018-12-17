using DormitorySystem.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService.TimedHostedServices
{
    public class TimedHostedAlarmService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedAlarmService> logger;
        private readonly IServiceProvider service;
        private Timer timer;

        public TimedHostedAlarmService(ILogger<TimedHostedAlarmService> logger, IServiceProvider service)
        {
            this.logger = logger;
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Check for unacceptable value is starting.");

            this.timer = new Timer(CheckForValidValue, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async void CheckForValidValue(object state)
        {
            this.logger.LogInformation("Check for unacceptable value");
            this.logger.LogInformation("_____________________");

            using (var scope = service.CreateScope())
            {
                var notificationsService
                    = scope.ServiceProvider.GetRequiredService<INotificationsService>();

                int count = await notificationsService.CheckForOutOfRangeSensorsAsync();
                this.logger.LogInformation($"In {count} sensors the value is out of range");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed background service is stopping.".ToUpper());

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timer?.Dispose();
        }
    }
}
