using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class AllSensorViewModel : BaseUserSensorViewModel
    {  
      
        public AllSensorViewModel(UserSensor model) : base(model)
        {
            UserEmail = model.User.Email;
        }

        public string UserEmail { get; set; }
    }
}
