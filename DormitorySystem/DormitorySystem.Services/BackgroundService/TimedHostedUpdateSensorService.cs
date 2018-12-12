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
    public class TimedHostedUpdateSensorService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IServiceProvider service;
        private Timer timer;
        private IDictionary<string, SampleSensor> listOfSensors;

        public TimedHostedUpdateSensorService(ILogger<TimedHostedUpdateSensorService> logger, IServiceProvider service)
        {
            this.logger = logger;
            this.service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Timed Background Service is starting.");

            string report = InitialSensorLoad();
            this.logger.LogInformation(report);

           // this.timer = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromHours(12));

            this.timer = new Timer(UpdateSensorAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

      

        private async void UpdateSensorAsync(object state)
        {
            this.logger.LogInformation("Start searching for outdated sensors.");

            using (var scope = service.CreateScope())
            {
                var iCBApiService = scope.ServiceProvider.GetRequiredService<IICBApiService>();
                listOfSensors = await iCBApiService.UpdateSensorsAsync(listOfSensors);
            }

            this.logger.LogInformation("Sensors are up to date.");
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