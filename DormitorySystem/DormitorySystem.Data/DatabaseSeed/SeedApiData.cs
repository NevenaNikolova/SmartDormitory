using DormitorySystem.Common.Abstractions;
using DormitorySystem.Common.Constants;
using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DormitorySystem.Data.DatabaseSeed
{
    public class SeedApiData : ISeedApiData
    {
        private readonly IApiProvider apiProvider;
        private JObject apiData;
        private Measure[] measureCollection;
        private SensorType[] typesCollection;
        private SampleSensor[] sensorCollection;

        public SeedApiData(IApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public async Task SetCollections()
        {
            this.apiData = await LoadApiDataAsync();

            var measures = CreateMeasuresCollection();
            var types = CreateTypesCollection();

            this.MeasureCollection = measures.Values.ToArray();
            this.TypesCollection = types.Values.ToArray();
            this.SensorCollection = CreateSensorsCollection(measures, types);
        }

        public Measure[] MeasureCollection
        {
            get => this.measureCollection; private set => this.measureCollection = value;
        }

        public SensorType[] TypesCollection
        {
            get => this.typesCollection; private set => this.typesCollection = value;
        }

        public SampleSensor[] SensorCollection
        {
            get => sensorCollection; private set => sensorCollection = value;
        }

        public async Task<JObject> LoadApiDataAsync()
        {
            var responseAll = await apiProvider.ReturnResponseAsync(ApiConstants.ICBSensorApiListAllSensor, ApiConstants.ICBApiAuthorizationToken);

            var response = "{" + "\"data\"" + ":" + responseAll.Value + "}";

            return JObject.Parse(response);
        }

        private SampleSensor[] CreateSensorsCollection
            (IDictionary<string, Measure> measures, IDictionary<string, SensorType> types)
        {
            var sampleSensorCollection = new List<SampleSensor>();

            foreach (var item in this.apiData["data"])
            {
                string description = item["Description"].ToString();
                var extractedValues = ExtractValues(description);
                string measure = item["MeasureType"].ToString();

                string tag = item["Tag"].ToString();
                string tagKey = tag.Substring(0, tag.IndexOf("Sensor"));

                int minPollInterval = int.TryParse
                    (item["MinPollingIntervalInSeconds"].ToString(), out int number)
                    ? number : 10;

                if (!Guid.TryParse(item["SensorId"].ToString(), out Guid sensorId))
                {
                    throw new FormatException("Invalid sensorId information from Api");
                }

                var newSensor = new SampleSensor()
                {
                    Id = sensorId,
                    Tag = tag,
                    Description = description,
                    MinPollingInterval = minPollInterval,
                    MeasureId = measures[measure].Id,
                    SensorTypeId = types[tagKey].Id,
                    MaxValue = Math.Max(extractedValues[0], extractedValues[1]),
                    MinValue = Math.Min(extractedValues[0], extractedValues[1]),
                    TimeStamp = DateTime.Now.ToString()
                };
                sampleSensorCollection.Add(newSensor);
            }

            return sampleSensorCollection.ToArray();
        }

        private IDictionary<string, Measure> CreateMeasuresCollection()
        {
            var result = new Dictionary<string, Measure>();

            foreach (var item in this.apiData["data"])
            {
                var measTypeKey = item["MeasureType"].ToString();
                if (!result.ContainsKey(measTypeKey))
                {
                    var mesureType = new Measure()
                    {
                        Id = result.Count + 1,
                        MeasureType = measTypeKey
                    };
                    result.Add(measTypeKey, mesureType);
                }
            }

            return result;
        }

        private IDictionary<string, SensorType> CreateTypesCollection()
        {
            var result = new Dictionary<string, SensorType>();

            foreach (var item in this.apiData["data"])
            {
                string tagFullName = item["Tag"].ToString();
                string tagForType = tagFullName.Substring(0, tagFullName.IndexOf("Sensor"));
                if (!result.ContainsKey(tagForType))
                {
                    var sensorType = new SensorType()
                    {
                        Id = result.Count + 1,
                        Name = tagForType
                    };
                    result.Add(tagForType, sensorType);
                }
            }

            return result;
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
