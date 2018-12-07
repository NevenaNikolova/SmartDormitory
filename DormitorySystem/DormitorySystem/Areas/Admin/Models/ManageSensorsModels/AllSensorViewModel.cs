using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
