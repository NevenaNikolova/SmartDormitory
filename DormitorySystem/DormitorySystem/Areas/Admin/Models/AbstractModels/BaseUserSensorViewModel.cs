using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models.AbstractModels
{
    public class BaseUserSensorViewModel
    {
        public BaseUserSensorViewModel(UserSensor model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.SampleSensor.SensorType.Name;
            CreatedOn = model.CreatedOn;
            ModifiedOn = model.ModifiedOn;
        }

        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Sensor Name")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Display(Name="Registered On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name="Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}
