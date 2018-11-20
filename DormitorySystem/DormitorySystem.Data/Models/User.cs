using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DormitorySystem.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public ICollection<UserSensor>Sensors{ get; set; }

        public bool GDPR { get; set; }
    }
}
