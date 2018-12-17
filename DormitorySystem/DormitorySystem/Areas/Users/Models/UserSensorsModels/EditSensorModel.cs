using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Users.Models.AbstractModels;
using System;

namespace DormitorySystem.Web.Areas.Users.Models.UserSensorsModels
{
    public class EditSensorModel : BaseRegisterEditViewModel
    {
        public EditSensorModel() { }
       

        public EditSensorModel(UserSensor model) : base(model)
        {
            this.RegisteredOn = model.CreatedOn;
        }

        public DateTime RegisteredOn { get; set; }
    }
}
