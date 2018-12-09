using DormitorySystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Users.Models.AbstractModels
{
    public class BaseUserSensorViewModel
    {
        public BaseUserSensorViewModel()
        {
        }

        public BaseUserSensorViewModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            IsPrivate = model.IsPrivate;
        }

        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name ="Sensor Name")]
        public string Name { get; set; }

        [Display(Name= "This Sensor is Visible only for Me")]
        public bool IsPrivate { get; set; }
    }
}
