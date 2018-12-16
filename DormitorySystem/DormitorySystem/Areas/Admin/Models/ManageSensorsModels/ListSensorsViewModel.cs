using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class ListSensorSViewModel
    {
        public ListSensorSViewModel()
        {
        }

        public ListSensorSViewModel
            (IEnumerable<ListSensorViewModel> userSensors, string userId, string userName)
        {
            this.UserSensors = userSensors;
            this.UserId = userId;
            this.UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<ListSensorViewModel> UserSensors { get; }
    }
}
