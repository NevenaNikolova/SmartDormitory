using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService
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
            this.logger.LogInformation("Timed Background Service is starting.");

            this.timer = new Timer(CheckForValidValue, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private async void CheckForValidValue(object state)
        {
            this.logger.LogInformation("CHECK FOR VALID VALUE");
            this.logger.LogInformation("_____________________");
            using (var scope = service.CreateScope())
            {
                var notificationsService
                    = scope.ServiceProvider.GetRequiredService<INotificationsService>();

                await notificationsService.CheckForOutOfRangeSensorsAsync();
            }
            this.logger.LogInformation("CHECKING IS DONE");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is stopping.".ToUpper());

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timer?.Dispose();
        }
    }
}
