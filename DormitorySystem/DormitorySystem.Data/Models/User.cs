using System;
using System.Collections.Generic;
using DormitorySystem.Data.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DormitorySystem.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser, IDeletable, IAuditable
    {
        public User()
        {

        }

        public ICollection<UserSensor>Sensors{ get; set; }

        public bool GDPR { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
