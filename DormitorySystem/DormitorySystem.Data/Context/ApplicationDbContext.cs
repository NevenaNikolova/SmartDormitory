using System;
using System.Text.RegularExpressions;
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace DormitorySystem.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Measure> Measures { get; set; }
        public DbSet<SampleSensor> SampleSensors { get; set; }
        public DbSet<SensorType> Types { get; set; }
        public DbSet<UserSensor> UserSensors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.GetApiData();

            this.SeedAdminUser(builder);

            base.OnModelCreating(builder);
        }

        private void SeedAdminUser(ModelBuilder builder)
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

            var adminUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "InitialAdmin",
                NormalizedUserName = "InitialAdmin".ToUpper(),
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

        private void GetApiData()
        {
            // throw new NotImplementedException();
        }

        //Double check min max value
        private double[] RegexMatch(string descr)
        {         
            var numbers = Regex.Matches(descr, @"(\+| -)?(\d+)(\,|\.)?(\d*)?");

            var result =new double[] {0,1};
            
            if (numbers.Count > 0)
            {
                double.TryParse(numbers[0].ToString(), out result[0]);
                double.TryParse(numbers[1].ToString(), out result[1]);
            }
            return result;         

        }
    }
}
