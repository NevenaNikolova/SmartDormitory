using DormitorySystem.Data.Models;

namespace DormitorySystem.Web.Models.SensorViewModels
{
    // Model for api
    public class SensorInformationViewModel
    {
        public SensorInformationViewModel(SampleSensor sampleSensor)
        {
            this.Value = sampleSensor.ValueCurrent;
            this.PollingInterval = sampleSensor.MinPollingInterval;
            this.Measure = sampleSensor.Measure.MeasureType;
        }

        public int PollingInterval { get; set; }
        public double Value { get; set; }
        public string Measure { get; set; }
    }
}
