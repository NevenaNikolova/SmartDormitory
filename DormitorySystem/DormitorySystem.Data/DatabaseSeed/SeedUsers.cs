using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Utilities;

namespace DormitorySystem.Data.DatabaseSeed
{
    public class SeedUsers : ISeedUsers
    {
        public void SeedRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
              .HasData(new IdentityRole
              {
                  Name = RoleType.Admin.ToString(),
                  Id = RoleType.Admin.ToString(),
                  NormalizedName = RoleType.Admin.ToString().ToUpper()
              });

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = RoleType.User.ToString(),
                    Id = RoleType.User.ToString(),
                    NormalizedName = RoleType.User.ToString().ToUpper()
                });
        }

        public void SeedAdmin(ModelBuilder builder)
        {
            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "InitialAdmin",
                NormalizedUserName = "InitialAdmin@system.com".ToUpper(),
                Email = "InitialAdmin@system.com",
                NormalizedEmail = "InitialAdmin@system.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+00000001",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var hashPass = new PasswordHasher<User>()
                .HashPassword(adminUser, "magicString");

            adminUser.PasswordHash = hashPass;

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = RoleType.Admin.ToString(),
                    UserId = adminUser.Id
                });
        }
    }
}
