using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class UserSensorDetailsModel : BaseUserSensorViewModel
    {
        public UserSensorDetailsModel(UserSensor model) : base(model)
        {
            this.UserPollingInterval = model.PollingInterval;
            this.Latitude = model.Latitude;
            this.Longitude = model.Longitude;
            this.SendNotification = model.SendNotification;
            this.IsPrivate = model.IsPrivate;
        }

        public int UserPollingInterval { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool SendNotification { get; set; }
        public bool IsPrivate { get; set; }
    }
}
