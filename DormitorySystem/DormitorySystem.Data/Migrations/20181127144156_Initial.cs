using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    GDPR = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeasureType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleSensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MinPollingInterval = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<string>(nullable: true),
                    ValueCurrent = table.Column<double>(nullable: false),
                    MinValue = table.Column<double>(nullable: true),
                    MaxValue = table.Column<double>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    isOnline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleSensors_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleSensors_SensorTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "SensorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSensors",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    SampleSensorId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PollingInterval = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    SendNotification = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSensors_SampleSensors_SampleSensorId",
                        column: x => x.SampleSensorId,
                        principalTable: "SampleSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSensors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "5df2d4d5-c50e-439e-8a76-085c5ab574d0", "Admin", "ADMIN" },
                    { "User", "8f979c90-3e2e-4ffe-8295-eb4b0ad06606", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", 0, "5a7c14d0-a27f-4ff8-a925-41e994a30b3e", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEMJlVD2R/aZzvKLwVo+HZ1p3vL7EMKqwRE6SMia61Ew5Q+LggsQygBY1wKN2V7p0pg==", "+00000001", true, "4e2525d4-2932-43c0-a6fe-2d0ecc6cdaba", false, "InitialAdmin", false });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "MeasureType" },
                values: new object[,]
                {
                    { 1, "°C" },
                    { 2, "%" },
                    { 3, "W" },
                    { 4, "(true/false)" },
                    { 5, "dB" }
                });

            migrationBuilder.InsertData(
                table: "SensorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Temperature" },
                    { 2, "Humidity" },
                    { 3, "ElectricPowerConsumtion" },
                    { 4, "Occupancy" },
                    { 5, "Door" },
                    { 6, "Noise" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", "Admin" });

            migrationBuilder.InsertData(
                table: "SampleSensors",
                columns: new[] { "Id", "Description", "MaxValue", "MeasureId", "MinPollingInterval", "MinValue", "Tag", "TimeStamp", "TypeId", "ValueCurrent", "isOnline" },
                values: new object[,]
                {
                    { new Guid("f1796a28-642e-401f-8129-fd7465417061"), "This sensor will return values between 15 and 28", 28.0, 1, 40, 15.0, "TemperatureSensor1", "27.11.2018 г. 16:41:54", 1, 0.0, false },
                    { new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"), "This sensor will return values between 6 and 18", 18.0, 1, 30, 6.0, "TemperatureSensor2", "27.11.2018 г. 16:41:54", 1, 0.0, false },
                    { new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"), "This sensor will return values between 19 and 23", 23.0, 1, 70, 19.0, "TemperatureSensor3", "27.11.2018 г. 16:41:54", 1, 0.0, false },
                    { new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"), "This sensor will return values between 0 and 60", 60.0, 2, 40, 0.0, "HumiditySensor1", "27.11.2018 г. 16:41:54", 2, 0.0, false },
                    { new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"), "This sensor will return values between 10 and 90", 90.0, 2, 50, 10.0, "HumiditySensor2", "27.11.2018 г. 16:41:54", 2, 0.0, false },
                    { new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"), "This sensor will return values between 1000 and 5000", 5000.0, 3, 70, 1000.0, "ElectricPowerConsumtionSensor1", "27.11.2018 г. 16:41:54", 3, 0.0, false },
                    { new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"), "This sensor will return values between 500 and 3500", 3500.0, 3, 105, 500.0, "ElectricPowerConsumtionSensor2", "27.11.2018 г. 16:41:54", 3, 0.0, false },
                    { new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"), "This sensor will return true or false value", 1.0, 4, 50, 0.0, "OccupancySensor1", "27.11.2018 г. 16:41:54", 4, 0.0, false },
                    { new Guid("7a3b1db5-959d-46ce-82b6-517773327427"), "This sensor will return true or false value", 1.0, 4, 80, 0.0, "OccupancySensor2", "27.11.2018 г. 16:41:54", 4, 0.0, false },
                    { new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"), "This sensor will return true or false value", 1.0, 4, 90, 0.0, "DoorSensor1", "27.11.2018 г. 16:41:54", 5, 0.0, false },
                    { new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"), "This sensor will return true or false value", 1.0, 4, 50, 0.0, "DoorSensor2", "27.11.2018 г. 16:41:54", 5, 0.0, false },
                    { new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"), "This sensor will return values between 20 and 70", 70.0, 5, 40, 20.0, "NoiseSensor1", "27.11.2018 г. 16:41:54", 6, 0.0, false },
                    { new Guid("65d98ff7-b524-49de-8d13-f85753d98858"), "This sensor will return values between 40 and 90", 90.0, 5, 85, 40.0, "NoiseSensor2", "27.11.2018 г. 16:41:54", 6, 0.0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SampleSensors_MeasureId",
                table: "SampleSensors",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleSensors_TypeId",
                table: "SampleSensors",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSensors_SampleSensorId",
                table: "UserSensors",
                column: "SampleSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSensors_UserId",
                table: "UserSensors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserSensors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SampleSensors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "SensorTypes");
        }
    }
}
