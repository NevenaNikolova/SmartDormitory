using DormitorySystem.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService.TimedHostedServices
{
    public class TimedHostedUpdateSensorService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IServiceProvider service;
        private Timer timer;

        public TimedHostedUpdateSensorService(ILogger<TimedHostedUpdateSensorService> logger, IServiceProvider service)
        {
            this.logger = logger;
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Update sensor service is starting.");

            this.timer = new Timer(UpdateSensorAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void UpdateSensorAsync(object state)
        {
            this.logger.LogInformation("Start searching for outdated sensors.");

            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                var count = await iCBApiService.UpdateSensorsAsync();

                this.logger.LogInformation($"{count} number of sensors are up to date.");
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