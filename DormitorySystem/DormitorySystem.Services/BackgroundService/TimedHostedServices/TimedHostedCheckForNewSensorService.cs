using DormitorySystem.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService.TimedHostedServices
{
    public class TimedHostedCheckForNewSensorService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IServiceProvider service;
        private Timer timer;

        public TimedHostedCheckForNewSensorService
            (ILogger<TimedHostedCheckForNewSensorService> logger, IServiceProvider service)
        {
            this.logger = logger;
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Check for new sensor Service is starting.");

            this.timer = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromHours(12));

            return Task.CompletedTask;
        }

        private async void CheckForNewSensor(object state)
        {
            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                var count = await iCBApiService.CheckForNewSensor();
                this.logger.LogInformation
                          ($"Checking for new sensor is complete. Number of new sensor found is: {count}");
            }
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
