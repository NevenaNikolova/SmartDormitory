using DormitorySystem.Data.Models;
using System.Threading.Tasks;

namespace DormitorySystem.Data.Abstractions
{
    public interface ISeedApiData
    {
        Task SetCollections();
        Measure[] MeasureCollection { get; }
        SensorType[] TypesCollection { get; }
        SampleSensor[] SensorCollection { get; }
    }
}
