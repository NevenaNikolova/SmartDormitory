using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class ChangedUserSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "bdb626f3-c005-4ef2-bd68-7acc4dbec6df", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bdb626f3-c005-4ef2-bd68-7acc4dbec6df", "f85166d2-8480-4800-a409-89f9182c9b82" });

            migrationBuilder.RenameColumn(
                name: "isOnline",
                table: "SampleSensors",
                newName: "IsOnline");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserSensors",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserMaxValue",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserMinValue",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "f607bb4d-fafd-4e27-b7fc-59f8b1b40f11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "d7e9eb52-fb4c-49ff-b591-d0783ddaebec");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "8da7d484-6177-4deb-93f5-c62e9002de73", 0, "d1e7c714-3bd3-4111-bccd-f2d111909970", DateTime.Now, null, "InitialAdmin@system.com", true, true, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEMTGdFtWi2MFF7jUagS5PxxVHkcRYiqnoFWh6mWDIPZx4Kjky+Q8xhgP/MG+2BZHZg==", "+00000001", true, "a3dfb9dd-00be-404b-a3b9-ad1399b7e6ea", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "3.12.2018 г. 13:22:07");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8da7d484-6177-4deb-93f5-c62e9002de73", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8da7d484-6177-4deb-93f5-c62e9002de73", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8da7d484-6177-4deb-93f5-c62e9002de73", "d1e7c714-3bd3-4111-bccd-f2d111909970" });

            migrationBuilder.DropColumn(
                name: "UserMaxValue",
                table: "UserSensors");

            migrationBuilder.DropColumn(
                name: "UserMinValue",
                table: "UserSensors");

            migrationBuilder.RenameColumn(
                name: "IsOnline",
                table: "SampleSensors",
                newName: "isOnline");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserSensors",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "f6b3fb2c-24f3-49a6-9b66-a8ea12dfbe97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "1b5de8bf-72ae-4a22-9422-eb6359619bb1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "bdb626f3-c005-4ef2-bd68-7acc4dbec6df", 0, "f85166d2-8480-4800-a409-89f9182c9b82", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEJtxHFP/XXHAEY/G15zZ2MpOYWh3qxwCk1q5TIPFzXJMfbOWKs/WGp+uM94dX7Sh9g==", "+00000001", true, "03e91d3d-b5c5-4019-aaa2-c1222031afe8", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "30.11.2018 г. 12:05:09");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "bdb626f3-c005-4ef2-bd68-7acc4dbec6df", "Admin" });
        }
    }
}
