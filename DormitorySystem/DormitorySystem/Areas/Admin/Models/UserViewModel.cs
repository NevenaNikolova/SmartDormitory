using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(Data.Models.User user)
        {
            Id = user.Id;
            Email = user.Email;
            UserName = user.UserName;
            GDPR = user.GDPR;
            isDeleted = user.isDeleted;
            DeletedOn = user.DeletedOn;
            CreatedOn = user.CreatedOn;
            ModifiedOn = user.ModifiedOn;
            Sensors = user.Sensors;           
        }
        public UserViewModel(Data.Models.User user, string roles)
        {
            Id = user.Id;
            Email = user.Email;
            UserName = user.UserName;
            GDPR = user.GDPR;
            isDeleted = user.isDeleted;
            DeletedOn = user.DeletedOn;
            CreatedOn = user.CreatedOn;
            ModifiedOn = user.ModifiedOn;
            Sensors = user.Sensors;
            Roles = roles;
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Display(Name ="Sensors")]
        public ICollection<UserSensor> Sensors { get; set; }

        [Required]
        public bool GDPR { get; set; }

        public bool isDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [Display(Name="Roles")]
        public string Roles { get; set; }
    }
}
