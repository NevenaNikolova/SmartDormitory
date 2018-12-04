using DormitorySystem.Data.Models;
using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public UserWithRolesViewModel()
        {

        }

        public UserWithRolesViewModel(User user, IEnumerable<string> roles)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Roles = roles;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
