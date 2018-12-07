using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;

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
