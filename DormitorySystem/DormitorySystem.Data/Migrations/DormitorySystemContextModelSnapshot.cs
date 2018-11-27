﻿// <auto-generated />
using System;
using DormitorySystem.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DormitorySystem.Data.Migrations
{
    [DbContext(typeof(DormitorySystemContext))]
    partial class DormitorySystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DormitorySystem.Data.Models.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeasureType");

                    b.HasKey("Id");

                    b.ToTable("Measures");

                    b.HasData(
                        new { Id = 1, MeasureType = "°C" },
                        new { Id = 2, MeasureType = "%" },
                        new { Id = 3, MeasureType = "W" },
                        new { Id = 4, MeasureType = "(true/false)" },
                        new { Id = 5, MeasureType = "dB" }
                    );
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.SampleSensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double?>("MaxValue");

                    b.Property<int>("MeasureId");

                    b.Property<int>("MinPollingInterval");

                    b.Property<double?>("MinValue");

                    b.Property<string>("Tag");

                    b.Property<string>("TimeStamp");

                    b.Property<int>("TypeId");

                    b.Property<double>("ValueCurrent");

                    b.Property<bool>("isOnline");

                    b.HasKey("Id");

                    b.HasIndex("MeasureId");

                    b.HasIndex("TypeId");

                    b.ToTable("SampleSensors");

                    b.HasData(
                        new { Id = new Guid("f1796a28-642e-401f-8129-fd7465417061"), Description = "This sensor will return values between 15 and 28", MaxValue = 28.0, MeasureId = 1, MinPollingInterval = 40, MinValue = 15.0, Tag = "TemperatureSensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 1, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"), Description = "This sensor will return values between 6 and 18", MaxValue = 18.0, MeasureId = 1, MinPollingInterval = 30, MinValue = 6.0, Tag = "TemperatureSensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 1, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"), Description = "This sensor will return values between 19 and 23", MaxValue = 23.0, MeasureId = 1, MinPollingInterval = 70, MinValue = 19.0, Tag = "TemperatureSensor3", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 1, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"), Description = "This sensor will return values between 0 and 60", MaxValue = 60.0, MeasureId = 2, MinPollingInterval = 40, MinValue = 0.0, Tag = "HumiditySensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 2, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"), Description = "This sensor will return values between 10 and 90", MaxValue = 90.0, MeasureId = 2, MinPollingInterval = 50, MinValue = 10.0, Tag = "HumiditySensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 2, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"), Description = "This sensor will return values between 1000 and 5000", MaxValue = 5000.0, MeasureId = 3, MinPollingInterval = 70, MinValue = 1000.0, Tag = "ElectricPowerConsumtionSensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 3, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"), Description = "This sensor will return values between 500 and 3500", MaxValue = 3500.0, MeasureId = 3, MinPollingInterval = 105, MinValue = 500.0, Tag = "ElectricPowerConsumtionSensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 3, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"), Description = "This sensor will return true or false value", MaxValue = 1.0, MeasureId = 4, MinPollingInterval = 50, MinValue = 0.0, Tag = "OccupancySensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 4, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("7a3b1db5-959d-46ce-82b6-517773327427"), Description = "This sensor will return true or false value", MaxValue = 1.0, MeasureId = 4, MinPollingInterval = 80, MinValue = 0.0, Tag = "OccupancySensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 4, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"), Description = "This sensor will return true or false value", MaxValue = 1.0, MeasureId = 4, MinPollingInterval = 90, MinValue = 0.0, Tag = "DoorSensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 5, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"), Description = "This sensor will return true or false value", MaxValue = 1.0, MeasureId = 4, MinPollingInterval = 50, MinValue = 0.0, Tag = "DoorSensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 5, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"), Description = "This sensor will return values between 20 and 70", MaxValue = 70.0, MeasureId = 5, MinPollingInterval = 40, MinValue = 20.0, Tag = "NoiseSensor1", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 6, ValueCurrent = 0.0, isOnline = false },
                        new { Id = new Guid("65d98ff7-b524-49de-8d13-f85753d98858"), Description = "This sensor will return values between 40 and 90", MaxValue = 90.0, MeasureId = 5, MinPollingInterval = 85, MinValue = 40.0, Tag = "NoiseSensor2", TimeStamp = "27.11.2018 г. 16:41:54", TypeId = 6, ValueCurrent = 0.0, isOnline = false }
                    );
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.SensorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SensorTypes");

                    b.HasData(
                        new { Id = 1, Name = "Temperature" },
                        new { Id = 2, Name = "Humidity" },
                        new { Id = 3, Name = "ElectricPowerConsumtion" },
                        new { Id = 4, Name = "Occupancy" },
                        new { Id = 5, Name = "Door" },
                        new { Id = 6, Name = "Noise" }
                    );
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("GDPR");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "57e6d534-f975-4c4c-a32a-7b9c75893c87", AccessFailedCount = 0, ConcurrencyStamp = "5a7c14d0-a27f-4ff8-a925-41e994a30b3e", Email = "InitialAdmin@system.com", EmailConfirmed = true, GDPR = false, LockoutEnabled = false, NormalizedEmail = "INITIALADMIN@SYSTEM.COM", NormalizedUserName = "INITIALADMIN@SYSTEM.COM", PasswordHash = "AQAAAAEAACcQAAAAEMJlVD2R/aZzvKLwVo+HZ1p3vL7EMKqwRE6SMia61Ew5Q+LggsQygBY1wKN2V7p0pg==", PhoneNumber = "+00000001", PhoneNumberConfirmed = true, SecurityStamp = "4e2525d4-2932-43c0-a6fe-2d0ecc6cdaba", TwoFactorEnabled = false, UserName = "InitialAdmin", isDeleted = false }
                    );
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.UserSensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("PollingInterval");

                    b.Property<Guid>("SampleSensorId");

                    b.Property<bool>("SendNotification");

                    b.Property<string>("UserId");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("SampleSensorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSensors");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "Admin", ConcurrencyStamp = "5df2d4d5-c50e-439e-8a76-085c5ab574d0", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "User", ConcurrencyStamp = "8f979c90-3e2e-4ffe-8295-eb4b0ad06606", Name = "User", NormalizedName = "USER" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new { UserId = "57e6d534-f975-4c4c-a32a-7b9c75893c87", RoleId = "Admin" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.SampleSensor", b =>
                {
                    b.HasOne("DormitorySystem.Data.Models.Measure", "Measure")
                        .WithMany("SampleSensors")
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DormitorySystem.Data.Models.SensorType", "Type")
                        .WithMany("SampleSensors")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DormitorySystem.Data.Models.UserSensor", b =>
                {
                    b.HasOne("DormitorySystem.Data.Models.SampleSensor", "SampleSensor")
                        .WithMany("UserSensors")
                        .HasForeignKey("SampleSensorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DormitorySystem.Data.Models.User", "User")
                        .WithMany("Sensors")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DormitorySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DormitorySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DormitorySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DormitorySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
