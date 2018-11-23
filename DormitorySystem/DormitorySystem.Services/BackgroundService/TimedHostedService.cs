using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.ServiceModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class TimedHostedService : IHostedService, IDisposable
{
    private readonly ILogger logger;
    private Timer timer;
    private IDictionary<string, SensorDataModel> listOfSensors;

    public TimedHostedService(ILogger<TimedHostedService> logger)
    {
        this.logger = logger;
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
        string urlAllSensors = "http://telerikacademy.icb.bg/api/sensor/all";
        var client = new WebClient();
        client.Headers.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

        var respons = client.DownloadString(urlAllSensors);
        respons = "{" + "\"data\"" + ":" + respons + "}";

        JObject sensorAPIJson = JObject.Parse(respons);

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
        string urlSensor = "http://telerikacademy.icb.bg/api/sensor/";
        var client = new WebClient();
        client.Headers.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

        ICollection<SampleSensor> sensorForUpdate = new List<SampleSensor>();

        bool isAnySensorForUpdata = false;
        foreach (var sensor in listOfSensors.Values)
        {
            if (sensor.TimeStamp < DateTime.Now)
            {
                sensor.TimeStamp = DateTime.Now;
                string respons = client.DownloadString(urlSensor + sensor.Id);
                JObject sensorResponse = JObject.Parse(respons);

                sensorForUpdate.Add(new SampleSensor()
                {
                    Id = Guid.Parse(sensor.Id),
                  //  ValueCurrent = double.Parse(sensorResponse["Value"].ToString()),
                    TimeStamp = sensor.TimeStamp.ToString()
                });

                isAnySensorForUpdata = true;
            }
        }

        if (isAnySensorForUpdata)
        {
            //using (var contextScope = new DormitorySystemContext())
            //{
            //    contextScope.UpdateRange(sensorForUpdate);
            //    contextScope.SaveChanges();
            //}
        }

        this.logger.LogInformation("Timed Background Service for updating sensors is working.");
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