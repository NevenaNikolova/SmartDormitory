using DormitorySystem.Data.Models;
using System.Threading.Tasks;

namespace DormitorySystem.Data.Abstractions
{
    public interface ISeedApiData
    {
        Task<bool> SetCollections();
        Measure[] MeasureCollection { get; }
        SensorType[] TypesCollection { get; }
        SampleSensor[] SensorCollection { get; }
    }
}
