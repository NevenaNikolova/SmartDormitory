using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Users.Models.AbstractModels;
using System;
using System.ComponentModel.DataAnnotations;

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
