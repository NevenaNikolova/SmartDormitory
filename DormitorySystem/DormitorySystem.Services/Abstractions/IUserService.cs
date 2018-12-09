using DormitorySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUsersService
    {
        Task<User> GetUserAsync(string Id);

        Task<IEnumerable<User>> ListUsersAsync();
    }
}
