using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Users.Models.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class EditSensorModel : BaseRegisterEditViewModel
    {      
        public EditSensorModel()
        {
        }

        public EditSensorModel(UserSensor model) : base(model)
        {
        }

    }
}
