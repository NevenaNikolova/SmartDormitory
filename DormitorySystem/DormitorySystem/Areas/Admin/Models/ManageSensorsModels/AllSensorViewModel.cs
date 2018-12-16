using DormitorySystem.Data.Models;
using DormitorySystem.Web.Areas.Admin.Models.AbstractModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageSensorsModels
{
    public class AllSensorViewModel : BaseUserSensorViewModel
    {

        public AllSensorViewModel(UserSensor model) : base(model)
        {
            this.UserEmail = model.User.Email;
            this.DeletedOn = model.DeletedOn;
        }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
