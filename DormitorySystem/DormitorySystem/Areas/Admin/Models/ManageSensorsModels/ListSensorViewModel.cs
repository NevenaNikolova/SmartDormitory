using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class ListSensorViewModel : BaseUserSensorViewModel
    {      
        
        public ListSensorViewModel(UserSensor model) : base(model)
        {
            UserPollingInterval = model.PollingInterval;
            IsPrivate = model.IsPrivate;
            SendNotification = model.SendNotification;

        }
        public int UserPollingInterval { get; set; }
        public bool IsPrivate { get; set; }
        public bool SendNotification { get; set; }
    }
}
