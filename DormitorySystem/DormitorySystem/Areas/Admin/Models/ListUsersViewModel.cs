using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitorySystem.Web.Areas.Admin.Models
{
    public class ListUsersViewModel
    {
        public IEnumerable<UserViewModel>Users { get; set; }

        public ListUsersViewModel(IEnumerable<UserViewModel> users)
        {
            Users = users;
        }
    }
}
