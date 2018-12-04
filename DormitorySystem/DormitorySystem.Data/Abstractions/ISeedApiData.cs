using DormitorySystem.Data.Models;

namespace DormitorySystem.Data.Abstractions
{
    public interface ISeedApiData
    {
        void SetCollections();
        Measure[] MeasureCollection { get; }
        SensorType[] TypesCollection { get; }
        SampleSensor[] SensorCollection { get; }
    }
}
