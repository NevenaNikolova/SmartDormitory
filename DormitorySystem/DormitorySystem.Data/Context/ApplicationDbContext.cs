using System;
<<<<<<< HEAD
using System.Text.RegularExpressions;
=======
using System.Collections.ObjectModel;
using System.Net;
>>>>>>> 64d6b44d6242d9fb5b5c5ac4fd792f2d774f758b
using DormitorySystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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

        private void GetApiData()
        {
            var client = new WebClient();
            client.Headers.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

            var responseAll = client.DownloadString("http://telerikacademy.icb.bg/api/sensor/all");
            responseAll = "{" + "\"data\"" + ":" + responseAll + "}";

            JObject json = JObject.Parse(responseAll);

            var sampleSensor = new Collection<SampleSensor>();

            int count = 1;
            try
            {
                foreach (var item in json["data"])
                {
                    var mesureType = new Measure()
                    {
                        MeasureType = item["MeasureType"].ToString(),
                        Id = count++
                    };

                    

                    var newSensor = new SampleSensor()
                    {
                        Id = new Guid(item["SensorId"].ToString()),
                        Tag = item["Tag"].ToString(),
                        Description = item["Description"].ToString(),
                        MinPollingInterval = int.Parse(item["MinPollingIntervalInSeconds"].ToString()),
                        Measure = mesureType,
                        MeasureId = mesureType.Id,
                    };
                    sampleSensor.Add(newSensor);
                }
            }
            // TODO catch exception
            catch (FormatException)
            {
                throw;
            }
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
