using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.AbstractModels
{
    public class BaseUserSensorViewModel
    {
        public BaseUserSensorViewModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.SampleSensor.SensorType.Name;
            CreatedOn = model.CreatedOn;
            ModifiedOn = model.ModifiedOn;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
