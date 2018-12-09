using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class AllSensorViewModel : BaseUserSensorViewModel
    {  
      
        public AllSensorViewModel(UserSensor model) : base(model)
        {
            UserEmail = model.User.Email;
        }

        [Display(Name="Email")]
        public string UserEmail { get; set; }
    }
}
