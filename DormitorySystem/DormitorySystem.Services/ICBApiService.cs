using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Abstractions;
using Utilities.Constants;

namespace DormitorySystem.Services
{
    public class ICBApiService : IICBApiService
    {
        private readonly DormitorySystemContext context;
        private readonly IApiProvider apiProvider;

        public ICBApiService(DormitorySystemContext context, IApiProvider apiProvider)
        {
            this.context = context;
            this.apiProvider = apiProvider;
        }

        public IDictionary<string, SampleSensor> InitialSensorLoad()
        {
            var result = new Dictionary<string, SampleSensor>();

            var sensors = this.context.SampleSensors;

            foreach (var sensor in sensors)
            {
                if (!result.ContainsKey(sensor.Id.ToString()))
                {
                    result.Add(sensor.Id.ToString(), sensor);
                }
            }
            return result;
        }

        public string CheckForNewSensor()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, SampleSensor> UpdateSensors(IDictionary<string, SampleSensor> listOfSensors)
        {
            ICollection<SampleSensor> sensorForUpdate = new List<SampleSensor>();

            bool isAnySensorForUpdata = false;
            foreach (var sensor in listOfSensors.Values)
            {
                if (DateTime.Parse(sensor.TimeStamp).AddSeconds(sensor.MinPollingInterval) < DateTime.Now)
                {
                    string response = apiProvider.ReturnRespons
                       (ApiConstants.ICBSensorApiBaseUrl + sensor.Id, ApiConstants.ICBApiAuthorizationToken);

                    JObject sensorResponse = JObject.Parse(response);

                    sensor.TimeStamp = sensorResponse["TimeStamp"].ToString();
                    sensor.ValueCurrent = InputValueConverter(sensorResponse["Value"].ToString());

                    sensorForUpdate.Add(sensor);

                    isAnySensorForUpdata = true;
                }
            }

            if (isAnySensorForUpdata)
            {
                context.UpdateRange(sensorForUpdate);
                context.SaveChanges();
            }

            return listOfSensors;
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
    }
}
