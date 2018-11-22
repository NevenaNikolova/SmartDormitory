using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class AddDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3f8d0007-4af6-42fb-94fb-e47ad6f066ac", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3f8d0007-4af6-42fb-94fb-e47ad6f066ac", "e5cfa491-83c2-40b1-bed3-24ad5ecf815b" });

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserSensors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "UserSensors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6cb3fd5a-759c-4495-8c70-8574e8667e14", "fa29f930-69b9-4a1c-81d1-8ca95c6ced91" });

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserSensors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserSensors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserSensors");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "UserSensors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "7057767f-b7bb-4274-9550-39f680b51dd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "aff09ab6-734d-48aa-b3e5-164b7d357716");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f8d0007-4af6-42fb-94fb-e47ad6f066ac", 0, "e5cfa491-83c2-40b1-bed3-24ad5ecf815b", "InitialAdmin@system.com", true, false, false, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEKz091Ly0MybDx7o72AyghqSHHllLovtiW54vUoExCQ+P0KT6SXo5e0Z4L4P08+2hw==", "+00000001", true, "dafbb6cf-2fbc-4181-a202-800bc1d2a0af", false, "InitialAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3f8d0007-4af6-42fb-94fb-e47ad6f066ac", "Admin" });
        }
    }
}
