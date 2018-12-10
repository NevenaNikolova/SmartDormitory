using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DormitorySystem.Data.Abstractions;
using DormitorySystem.Data.Models;
using DormitorySystem.Data.Models.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DormitorySystem.Data.Context
{
    public class DormitorySystemContext : IdentityDbContext<User>
    {
        private readonly ISeedUsers seedUsers;
        private readonly ISeedApiData seedApiData;

        public DormitorySystemContext
            (DbContextOptions<DormitorySystemContext> options,
            ISeedUsers seedUsers,
            ISeedApiData seedApiData)
            : base(options)
        {
            this.seedUsers = seedUsers;
            this.seedApiData = seedApiData;
        }

        public DbSet<Measure> Measures { get; set; }
        public DbSet<SampleSensor> SampleSensors { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<UserSensor> UserSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.seedUsers.SeedRole(builder);
            this.seedUsers.SeedAdmin(builder);
            this.seedApiData.SetCollections().Wait();

            builder.Entity<Measure>().HasData(this.seedApiData.MeasureCollection);
            builder.Entity<SensorType>().HasData(this.seedApiData.TypesCollection);
            builder.Entity<SampleSensor>().HasData(this.seedApiData.SensorCollection);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletionRules();
            return base.SaveChangesAsync(cancellationToken);
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

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
