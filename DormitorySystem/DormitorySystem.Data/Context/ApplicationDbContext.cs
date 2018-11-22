using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using DormitorySystem.Data.Models;
using DormitorySystem.Data.Models.Abstractions;
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
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<UserSensor> UserSensors { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletionRules();
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.GetApiData(builder);

            this.SeedAdminUser(builder);

            base.OnModelCreating(builder);
        }
        private void ApplyDeletionRules()
        {
            var entitiesForDeletion = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Entity is IDeletable);

            foreach (var entry in entitiesForDeletion)
            {
                var entity = (IDeletable)entry.Entity;
                entity.DeletedOn = DateTime.Now;
                entity.isDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) 
                || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
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

        private void GetApiData(ModelBuilder builder)
        {
            // TODO Refactoring
            string urlAllSensors = "http://telerikacademy.icb.bg/api/sensor/all";
            var client = new WebClient();
            client.Headers.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

            var responseAll = client.DownloadString(urlAllSensors);
            responseAll = "{" + "\"data\"" + ":" + responseAll + "}";

            JObject allSansors = JObject.Parse(responseAll);

            var sampleSensorCollection = new Collection<SampleSensor>();
            var measureCollection = new Dictionary<string, Measure>();
            var sensorTypesCollection = new Dictionary<string, SensorType>();

            try
            {
                foreach (var item in allSansors["data"])
                {
                    var measTypeKey = item["MeasureType"].ToString();
                    if (!measureCollection.ContainsKey(measTypeKey))
                    {
                        var mesureType = new Measure()
                        {
                            Id = measureCollection.Count + 1,
                            MeasureType = measTypeKey
                        };
                        measureCollection.Add(measTypeKey, mesureType);
                    }

                    string tagNameKey = item["Tag"].ToString();
                    tagNameKey = tagNameKey.Substring(0, tagNameKey.IndexOf("Sensor"));
                    if (!sensorTypesCollection.ContainsKey(tagNameKey))
                    {
                        var sensorType = new SensorType()
                        {
                            Id = sensorTypesCollection.Count + 1,
                            Name = tagNameKey
                        };
                        sensorTypesCollection.Add(tagNameKey, sensorType);
                    }

                    var newSensor = new SampleSensor()
                    {
                        Id = new Guid(item["SensorId"].ToString()),
                        Tag = tagNameKey,
                        Description = item["Description"].ToString(),
                        MinPollingInterval = int.Parse(item["MinPollingIntervalInSeconds"].ToString()),
                        MeasureId = measureCollection[measTypeKey].Id,
                        TypeId = sensorTypesCollection[tagNameKey].Id,
                    };
                    sampleSensorCollection.Add(newSensor);
                }
            }
            // TODO catch exception
            catch (FormatException)
            {
                //throw;
            }

            builder.Entity<Measure>().HasData(measureCollection.Values.ToArray());
            builder.Entity<SensorType>().HasData(sensorTypesCollection.Values.ToArray());
            builder.Entity<SampleSensor>().HasData(sampleSensorCollection.ToArray());
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
