using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class AddUserInUserSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId",
                table: "UserSensors");

            migrationBuilder.DropIndex(
                name: "IX_UserSensors_UserId",
                table: "UserSensors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "fa29f930-69b9-4a1c-81d1-8ca95c6ced91" });

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserSensors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "96f4b968-3683-44cb-9d96-1a8a134a6af9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "020282d3-fbfe-4602-853c-3bf8aed16895");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "3d4b5eeb-999e-4c62-857f-15f66dd973b2", 0, "35428375-17cc-4128-ac5e-f4ffa2af7327", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAECS3oc0kjRjDLgaRg1IcpMlDcVoe0HhVVxOCC1M0HQSy41RbweE7WuD74cDF+gIUvQ==", "+00000001", true, "4313ad83-b6cb-4dc7-8925-d22bbe787af8", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 5000.0, 1000.0, "ElectricPowerConsumtionSensor1", 6 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 60.0, 0.0, "HumiditySensor1", 4 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 90.0, 10.0, "HumiditySensor2", 5 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 18.0, 6.0, "TemperatureSensor2", 2 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 23.0, 19.0, "TemperatureSensor3", 3 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                columns: new[] { "MaxValue", "MinValue", "Tag" },
                values: new object[] { 28.0, 15.0, "TemperatureSensor1" });

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Temperature");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Temperature");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Humidity");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Humidity");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "ElectricPowerConsumtion");

            migrationBuilder.InsertData(
                table: "SensorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "ElectricPowerConsumtion" },
                    { 8, "Occupancy" },
                    { 9, "Occupancy" },
                    { 10, "Door" },
                    { 11, "Door" },
                    { 12, "Noise" },
                    { 13, "Noise" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3d4b5eeb-999e-4c62-857f-15f66dd973b2", "Admin" });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 3500.0, 500.0, "ElectricPowerConsumtionSensor2", 7 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 1.0, 0.0, "OccupancySensor1", 8 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 90.0, 40.0, "NoiseSensor2", 13 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 1.0, 0.0, "OccupancySensor2", 9 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 1.0, 0.0, "DoorSensor1", 10 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 70.0, 20.0, "NoiseSensor1", 12 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { 1.0, 0.0, "DoorSensor2", 11 });

            migrationBuilder.CreateIndex(
                name: "IX_UserSensors_UserId1",
                table: "UserSensors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId1",
                table: "UserSensors",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId1",
                table: "UserSensors");

            migrationBuilder.DropIndex(
                name: "IX_UserSensors_UserId1",
                table: "UserSensors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3d4b5eeb-999e-4c62-857f-15f66dd973b2", "Admin" });

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3d4b5eeb-999e-4c62-857f-15f66dd973b2", "35428375-17cc-4128-ac5e-f4ffa2af7327" });

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSensors");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSensors",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "23df1d75-2f79-4ded-9c10-17912ead77a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "2d1cd99c-8eb2-450b-9aa1-685811f4bff1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", 0, "fa29f930-69b9-4a1c-81d1-8ca95c6ced91", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAECcYvxXQzFft1PLTtUuFIiYVufRB1ZxX3i5fjqj8hs0E3UXKowUsrYu2s9tBhkt0qA==", "+00000001", true, "7f34483b-e220-48fe-bf53-55673b7d55dc", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "ElectricPowerConsumtion", 3 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "ElectricPowerConsumtion", 3 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Humidity", 2 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Occupancy", 4 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Humidity", 2 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Noise", 6 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Occupancy", 4 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Temperature", 1 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Temperature", 1 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Door", 5 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Noise", 6 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                columns: new[] { "MaxValue", "MinValue", "Tag", "TypeId" },
                values: new object[] { null, null, "Door", 5 });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                columns: new[] { "MaxValue", "MinValue", "Tag" },
                values: new object[] { null, null, "Temperature" });

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Humidity");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "ElectricPowerConsumtion");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Occupancy");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Door");

            migrationBuilder.UpdateData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Noise");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSensors_UserId",
                table: "UserSensors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId",
                table: "UserSensors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
