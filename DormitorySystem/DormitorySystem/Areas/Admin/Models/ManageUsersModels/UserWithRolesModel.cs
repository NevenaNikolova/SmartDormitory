using DormitorySystem.Data.Models;
using System.Collections.Generic;

namespace DormitorySystem.Web.Areas.Admin.Models.ManageUsersModels
{
    public class UserWithRolesModel
    {
        public UserWithRolesModel()
        {

        }

        public UserWithRolesModel(User user, IEnumerable<string> roles)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Roles = roles;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
