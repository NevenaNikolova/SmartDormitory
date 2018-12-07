using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Users.Models.SampleSensorsModels
{
    public class ListSampleSensorViewModel
    {
        public ListSampleSensorViewModel
            (IEnumerable<SampleSensorViewModel> sampleSensors, string userId)
        {
            this.SampleSensors = sampleSensors;
            this.UserId = userId;
        }

        public IEnumerable<SampleSensorViewModel> SampleSensors { get; }
        public string UserId { get; }
    }
}
