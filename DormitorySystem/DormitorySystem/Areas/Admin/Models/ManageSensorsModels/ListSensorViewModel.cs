using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class ListSensorViewModel : BaseUserSensorViewModel
    {

        public ListSensorViewModel(UserSensor model) : base(model)
        {
            this.UserPollingInterval = model.PollingInterval;
            this.IsPrivate = model.IsPrivate;
            this.SendNotification = model.SendNotification;

        }
        [Display(Name = "Update Interval in Seconds")]
        public int UserPollingInterval { get; set; }

        [Display(Name = "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }

        [Display(Name = "Values Out of Range Alert")]
        public bool SendNotification { get; set; }
    }
}
