using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.User.Models
{
    public class ListSampleSensorsViewModel
    {
        public IEnumerable<SampleSensorViewModel> SampleSensors { get; set; }

        public ListSampleSensorsViewModel(IEnumerable<SampleSensorViewModel> sampleSensors)
        {
            SampleSensors = sampleSensors;
        }
    }
}
