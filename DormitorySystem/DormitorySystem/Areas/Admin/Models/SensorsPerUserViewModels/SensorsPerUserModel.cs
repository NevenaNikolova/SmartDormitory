using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Admin.Models.SensorsPerUserViewModels
{
    public class SensorsPerUserModel
    {
        public SensorsPerUserModel()
        {
        }

        public SensorsPerUserModel
            (IEnumerable<SingleSensorPerUserModel> userSensors, string userId, string userName)
        {
            this.UserSensors = userSensors;
            this.UserId = userId;
            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<SingleSensorPerUserModel> UserSensors { get; }
    }
}
