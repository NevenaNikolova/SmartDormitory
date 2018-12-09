using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using DormitorySystem.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitorySystem.Services.AppServices
{
    public class UserService : IUsersService
    {
        private readonly DormitorySystemContext contex;

        public UserService(DormitorySystemContext contex)
        {
            this.contex = contex;
        }

        public async Task<IEnumerable<User>> ListUsersAsync()
        {
            var users = await this.contex.Users
                .Include(u => u.Sensors)
                .ToListAsync();

            return users;
        }
    }
}
