using DormitorySystem.Web.Models.SensorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models
{
    public class ListUserSensorsViewModel
    {
        public ListUserSensorsViewModel()
        {
        }

        public ListUserSensorsViewModel
            (IEnumerable<UserSensorViewModel> userSensors, string userId, string userName)
        {
            this.UserSensors = userSensors;
            this.UserId = userId;
            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<UserSensorViewModel> UserSensors { get; }
    }
}
