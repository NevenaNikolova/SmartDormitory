using DormitorySystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.Abstractions
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> ListUsersAsync();

        Task<User> DeleteUserAsync(string Id);
    }
}
