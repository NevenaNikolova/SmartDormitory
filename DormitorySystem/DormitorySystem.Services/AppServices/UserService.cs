using DormitorySystem.Common.Exceptions;
using DormitorySystem.Data.Context;
using DormitorySystem.Data.Models;
using DormitorySystem.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<User> GetUserWithSensorsAsync(string userId)
        {
            var user = await this.contex.Users
                .Include(u => u.Sensors)
                .SingleOrDefaultAsync(u => u.Id == userId)
                ?? throw new UserNullableException("There is no such user.");

            return user;
        }

        public async Task<IEnumerable<User>> ListUsersAsync()
        {
            var users = await this.contex.Users
                .Include(u => u.Sensors)
                .ToListAsync()
                ?? throw new UserNullableException("No users found.");

            return users;
        }

        public async Task<User> DeleteUserAsync(string Id)
        {
            var user = await this.contex.Users
                .SingleOrDefaultAsync(u => u.Id == Id)
                ?? throw new UserNullableException("There is no such user.");

            user.isDeleted = true;
            user.DeletedOn = DateTime.Now;

            await this.contex.SaveChangesAsync();
            return user;
        }
    }
}
