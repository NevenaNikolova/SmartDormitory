using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models
{
    public class ListUserSensorsViewModel
    {
        public IEnumerable<UserSensorViewModel> UserSensors { get; set; }

        public ListUserSensorsViewModel(IEnumerable<UserSensorViewModel> userSensors)
        {
            UserSensors = userSensors;
        }
    }
}
