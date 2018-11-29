using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class ChangedTypeToSensorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensors_SensorTypes_TypeId",
                table: "SampleSensors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", "5a7c14d0-a27f-4ff8-a925-41e994a30b3e" });

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "SampleSensors",
                newName: "SensorTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensors_TypeId",
                table: "SampleSensors",
                newName: "IX_SampleSensors_SensorTypeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "c7faf11c-6c95-40b8-ba8e-52cedd7a917f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "cfc5142e-3ee7-4f36-b38b-c743f0f2b9e8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "41579000-e126-4399-89eb-b082eeca8f7a", 0, "f474e41e-750f-4841-9b92-58d5c3bac627", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEH0s/s7IxU0xNR4zsiSgG44cU9lQW3TMkfAEmkV65ORPVz8mEBHnadlbsCkYRCt4mw==", "+00000001", true, "93c03f41-9590-47c7-a2b8-3032bd34675b", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "29.11.2018 г. 16:03:22");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "41579000-e126-4399-89eb-b082eeca8f7a", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensors_SensorTypes_SensorTypeId",
                table: "SampleSensors",
                column: "SensorTypeId",
                principalTable: "SensorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensors_SensorTypes_SensorTypeId",
                table: "SampleSensors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "41579000-e126-4399-89eb-b082eeca8f7a", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "41579000-e126-4399-89eb-b082eeca8f7a", "f474e41e-750f-4841-9b92-58d5c3bac627" });

            migrationBuilder.RenameColumn(
                name: "SensorTypeId",
                table: "SampleSensors",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensors_SensorTypeId",
                table: "SampleSensors",
                newName: "IX_SampleSensors_TypeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "5df2d4d5-c50e-439e-8a76-085c5ab574d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "8f979c90-3e2e-4ffe-8295-eb4b0ad06606");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", 0, "5a7c14d0-a27f-4ff8-a925-41e994a30b3e", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEMJlVD2R/aZzvKLwVo+HZ1p3vL7EMKqwRE6SMia61Ew5Q+LggsQygBY1wKN2V7p0pg==", "+00000001", true, "4e2525d4-2932-43c0-a6fe-2d0ecc6cdaba", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "27.11.2018 г. 16:41:54");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "57e6d534-f975-4c4c-a32a-7b9c75893c87", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensors_SensorTypes_TypeId",
                table: "SampleSensors",
                column: "TypeId",
                principalTable: "SensorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
