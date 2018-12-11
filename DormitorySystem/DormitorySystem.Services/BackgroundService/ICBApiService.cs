using DormitorySystem.Common.Abstractions;
using DormitorySystem.Common.Constants;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DormitorySystem.Services.BackgroundService
{
    public class ICBApiService : IICBApiService
    {
        private readonly DormitorySystemContext context;
        private readonly IApiProvider apiProvider;
        private readonly INotificationsService notifications;

        public ICBApiService(DormitorySystemContext context,
            IApiProvider apiProvider,
            INotificationsService notifications)
        {
            this.context = context;
            this.apiProvider = apiProvider;
            this.notifications = notifications;
        }

        public IDictionary<string, SampleSensor> InitialSensorLoad()
        {
            var result = new Dictionary<string, SampleSensor>();

            var sensors = this.context.SampleSensors.ToList();

            foreach (var sensor in sensors)
            {
                if (!result.ContainsKey(sensor.Id.ToString()))
                {
                    result.Add(sensor.Id.ToString(), sensor);
                }
            }
            return result;
        }

        public async Task<IDictionary<string, SampleSensor>> CheckForNewSensor
            (IDictionary<string, SampleSensor> listOfSensors)
        {
            var response = await apiProvider.ReturnResponseAsync
                       (ApiConstants.ICBSensorApiListAllSensor,
                       ApiConstants.ICBApiAuthorizationToken);

            if (response.Key)
            {
                var result = "{" + "\"data\"" + ":" + response.Value + "}";

                JObject allApiSensores = JObject.Parse(result);

                foreach (var sensor in allApiSensores["data"])
                {
                    string sensorId = sensor["SensorId"].ToString();

                    if (!listOfSensors.ContainsKey(sensorId))
                    {
                        var measureType = sensor["MeasureType"].ToString();
                        string tag = sensor["Tag"].ToString();
                        string typeTag = tag.Substring(0, tag.IndexOf("Sensor"));

                        var measure = await CheckForNewMeasureType(measureType);
                        var type = await CheckForNewSensorType(typeTag);

                        listOfSensors.Add(sensorId, await AddNewSensoreToDatabase(measure, type, sensor));
                    }
                }
            }

            return listOfSensors;
        }

        private async Task<SampleSensor> AddNewSensoreToDatabase
            (Measure measure, SensorType type, JToken sensorData)
        {
            string description = sensorData["Description"].ToString();
            var extractedValues = ExtractValues(description);
            string tag = sensorData["Tag"].ToString();

            int minPollInterval = int.TryParse
                (sensorData["MinPollingIntervalInSeconds"].ToString(), out int number)
                ? number : 10;

            if (!Guid.TryParse(sensorData["SensorId"].ToString(), out Guid sensorId))
            {
                throw new FormatException("Invalid sensorId information from Api");
            }

            var newSensor = new SampleSensor()
            {
                Id = sensorId,
                Tag = tag,
                Description = description,
                MinPollingInterval = minPollInterval,
                MeasureId = measure.Id,
                SensorTypeId = type.Id,
                MaxValue = Math.Max(extractedValues[0], extractedValues[1]),
                MinValue = Math.Min(extractedValues[0], extractedValues[1]),
                TimeStamp = DateTime.Now.ToString()
            };

            await this.context.SampleSensors.AddAsync(newSensor);
            await this.context.SaveChangesAsync();

            return newSensor;
        }

        private async Task<SensorType> CheckForNewSensorType(string typeTag)
        {
            var result = this.context.SensorTypes
                .SingleOrDefault(t => t.Name == typeTag);

            if (result == null)
            {
                result = new SensorType()
                {
                    Name = typeTag
                };
                await this.context.SensorTypes.AddAsync(result);
                await this.context.SaveChangesAsync();
            }

            return result;
        }

        private async Task<Measure> CheckForNewMeasureType(string measureType)
        {
            var result = this.context.Measures
                .SingleOrDefault(m => m.MeasureType == measureType);

            if (result == null)
            {
                result = new Measure()
                {
                    MeasureType = measureType
                };

                await this.context.Measures.AddAsync(result);
                await this.context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IDictionary<string, SampleSensor>> UpdateSensors(IDictionary<string, SampleSensor> listOfSensors)
        {
            ICollection<SampleSensor> sensorForUpdate = new List<SampleSensor>();

            bool isAnySensorForUpdate = false;
            foreach (var sensor in listOfSensors.Values)
            {
                if (DateTime.Parse(sensor.TimeStamp).AddSeconds(sensor.MinPollingInterval) < DateTime.Now)
                {
                    var response = await apiProvider.ReturnResponseAsync
                       (ApiConstants.ICBSensorApiBaseUrl
                       + sensor.Id, ApiConstants.ICBApiAuthorizationToken);

                    if (response.Key)
                    {
                        JObject sensorResponse = JObject.Parse(response.Value);

                        sensor.TimeStamp = sensorResponse["TimeStamp"].ToString();
                        sensor.ValueCurrent = InputValueConverter(sensorResponse["Value"].ToString());
                        sensor.IsOnline = true;
                    }
                    else
                    {
                        sensor.TimeStamp = DateTime.Now.ToString();
                        sensor.IsOnline = false;
                    }

                    sensorForUpdate.Add(sensor);
                    isAnySensorForUpdate = true;
                }
            }

            if (isAnySensorForUpdate)
            {
                this.context.UpdateRange(sensorForUpdate);
                await this.context.SaveChangesAsync();
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

        //Double check min max value
        private double[] ExtractValues(string descr)
        {
            var numbers = Regex.Matches(descr, @"(\+| -)?(\d+)(\,|\.)?(\d*)?");

            var result = new double[] { 0, 1 };

            if (numbers.Count > 0)
            {
                double.TryParse(numbers[0].ToString(), out result[0]);
                double.TryParse(numbers[1].ToString(), out result[1]);
            }
            return result;
        }
    }
}
