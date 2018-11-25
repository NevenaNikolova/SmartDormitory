using DormitorySystem.Data.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DormitorySystem.Data.Abstractions
{
    public interface ISeedApiData
    {
        Measure[] MeasureCollection { get; }
        SensorType[] TypesCollection { get; }
        SampleSensor[] SensorCollection { get; }
    }
}
