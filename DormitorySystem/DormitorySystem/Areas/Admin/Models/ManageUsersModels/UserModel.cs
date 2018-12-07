using DormitorySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(User user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.GDPR = user.GDPR;
            this.IsDeleted = user.isDeleted;
            this.DeletedOn = user.DeletedOn;
            this.CreatedOn = user.CreatedOn;
            this.ModifiedOn = user.ModifiedOn;
            this.Sensors = user.Sensors;
        }

        public UserModel(User user, string roles) : this(user)
        {
            this.Roles = roles;
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Display(Name = "Sensors")]
        public ICollection<UserSensor> Sensors { get; set; }

        [Required]
        public bool GDPR { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}
