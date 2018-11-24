using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.ServiceModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Constants;
using Utilities.WebProvider;

public class TimedHostedService : IHostedService, IDisposable
{
    private readonly ILogger logger;
    private readonly IServiceProvider service;
    private Timer timer;
    private IDictionary<string, SensorDataModel> listOfSensors;

    public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider service)
    {
        this.logger = logger;
        this.service = service;
        listOfSensors = new Dictionary<string, SensorDataModel>();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Timed Background Service is starting.");

        this.timer = new Timer(CheckForNewSensor, null, TimeSpan.Zero, TimeSpan.FromHours(24));

        this.timer = new Timer(UpdateSensor, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void CheckForNewSensor(object state)
    {
        string response;
        using (var scope = service.CreateScope())
        {
            var apiProvider = scope.ServiceProvider.GetRequiredService<IApiProvider>();

            response = apiProvider.ReturnRespons
               (ApiConstants.ICBSensorApiListAllSensor, ApiConstants.ICBApiAuthorizationToken);
        }

        response = "{" + "\"data\"" + ":" + response + "}";

        JObject sensorAPIJson = JObject.Parse(response);

        foreach (var item in sensorAPIJson["data"])
        {
            var sensorId = item["SensorId"].ToString();
            if (!listOfSensors.ContainsKey(sensorId))
            {
                var minPollingInterval = item["MinPollingIntervalInSeconds"].ToString();
                listOfSensors.Add(sensorId, new SensorDataModel(sensorId, minPollingInterval));
            }
        }

        this.logger.LogInformation("Timed Background Service for CheckForNewSensor is working.");
    }

    private void UpdateSensor(object state)
    {

        ICollection<SampleSensor> sensorForUpdate = new List<SampleSensor>();

        bool isAnySensorForUpdata = false;
        foreach (var sensor in listOfSensors.Values)
        {
            if (sensor.TimeStamp < DateTime.Now)
            {
                sensor.TimeStamp = DateTime.Now;

                string response;

                using (var scope = service.CreateScope())
                {
                    var apiProvider = scope.ServiceProvider.GetRequiredService<IApiProvider>();

                    response = apiProvider.ReturnRespons
                   (ApiConstants.ICBSensorApiBaseUrl + sensor.Id, ApiConstants.ICBApiAuthorizationToken);
                }

                JObject sensorResponse = JObject.Parse(response);

                sensorForUpdate.Add(new SampleSensor()
                {
                    Id = Guid.Parse(sensor.Id),
                    ValueCurrent = InputValueConverter(sensorResponse["Value"].ToString()),
                    TimeStamp = sensor.TimeStamp.ToString(),
                    MeasureId = 1,
                    TypeId = 1,
                });

                isAnySensorForUpdata = true;
            }
        }

        if (isAnySensorForUpdata)
        {
            using (var scope = this.service.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DormitorySystemContext>();
                context.UpdateRange(sensorForUpdate);
                context.SaveChanges();
            }
        }

        this.logger.LogInformation("Timed Background Service for updating sensors is working.");
    }

    private double InputValueConverter(string inputValue)
    {
        if (double.TryParse(inputValue, out double result))
        {
            return result;
        }
        else
        {
            return inputValue.ToLower() == "true" ? 1 : 0;
        }
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