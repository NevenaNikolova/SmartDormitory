using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.SensorsPerUserViewModels
{
    public class SingleSensorPerUserModel
    {
        public SingleSensorPerUserModel()
        {
        }

        public SingleSensorPerUserModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.SampleSensor.SensorType.Name;
            RegisteredOn = model.CreatedOn;
            ModifiedOn = model.ModifiedOn;
            UserPollingInterval = model.PollingInterval;
            IsPrivate = model.IsPrivate;
            SendNotification = model.SendNotification;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int UserPollingInterval { get; set; }
        public bool IsPrivate { get; set; }
        public bool SendNotification { get; set; }
    }
}
