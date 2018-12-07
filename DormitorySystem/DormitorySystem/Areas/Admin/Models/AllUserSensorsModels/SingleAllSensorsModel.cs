using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.AllUserSensorsModels
{
    public class SingleAllSensorsModel
    {
        public SingleAllSensorsModel()
        {
        }

        public SingleAllSensorsModel(UserSensor model)
        {
            Id = model.Id;
            UserEmail = model.User.Email;
            Name = model.Name;
            Type = model.SampleSensor.SensorType.Name;
            CreatedOn = model.CreatedOn;
            ModifiedOn = model.ModifiedOn;
        }

        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
