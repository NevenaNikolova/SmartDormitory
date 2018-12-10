using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IServiceProvider service;
        private Timer timer;
        private IDictionary<string, SampleSensor> listOfSensors;

        public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider service)
        {
            this.logger = logger;
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is starting.");

            string report = InitialSensorLoad();
            this.logger.LogInformation(report);

            this.timer = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromHours(24));

            this.timer = new Timer(UpdateSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void CheckForNewSensor(object state)
        {
            int number = listOfSensors.Count;

            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                listOfSensors = await iCBApiService.CheckForNewSensor(listOfSensors);
            }

            number = listOfSensors.Count - number;

            this.logger.LogInformation
            ($"Checking for new sensor is complete. Number of new sensor found is: {number}");
        }

        private string InitialSensorLoad()
        {
            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                listOfSensors = iCBApiService.InitialSensorLoad();
            }

            return $"Initial sensor load was completed on {DateTime.Now.Date}";
        }

        private async void UpdateSensor(object state)
        {
            this.logger.LogInformation("Start searching for outdated sensors.");

            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                listOfSensors = await iCBApiService.UpdateSensors(listOfSensors);
            }

            this.logger.LogInformation("Sensors are up to date.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is stopping.");

            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timer?.Dispose();
        }
    }
}