using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class AddMinMaxValue_AddGDPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "e0f32e9e-ce99-426b-a570-39a32d19537a" });

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "SampleSensors",
                newName: "ValueCurrent");

            migrationBuilder.AddColumn<double>(
                name: "MaxValue",
                table: "SampleSensors",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinValue",
                table: "SampleSensors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GDPR",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "a3ceb02c-fab6-4295-9678-0580113ad8a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "02bb63da-0cf7-4404-a9da-e5f08e7a71a8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d7705e8-52de-46e1-9109-ca3fb7938876", 0, "379ad7f4-de13-410e-82d0-bc4a3a491a45", "InitialAdmin@system.com", true, false, false, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN", "AQAAAAEAACcQAAAAECrWybnF0rmh3rg25OG9YsM5sN37NvaDZrQ/NezBtWrrPLnqTj17GalT1jLrphRN6g==", "+00000001", true, "0b811a12-7273-49dd-8d09-4ab8f192530a", false, "InitialAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3d7705e8-52de-46e1-9109-ca3fb7938876", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3d7705e8-52de-46e1-9109-ca3fb7938876", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3d7705e8-52de-46e1-9109-ca3fb7938876", "379ad7f4-de13-410e-82d0-bc4a3a491a45" });

            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "SampleSensors");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "SampleSensors");

            migrationBuilder.DropColumn(
                name: "GDPR",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ValueCurrent",
                table: "SampleSensors",
                newName: "Value");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "5fb87322-cbea-44bf-9de7-171ff00775b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "730a0b98-3190-475e-b960-6f82a508b15e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", 0, "e0f32e9e-ce99-426b-a570-39a32d19537a", "InitialAdmin@system.com", true, false, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN", "AQAAAAEAACcQAAAAEOLs/53maxska07LVxI03pZcI6KW8b9+qwRHDIF3wsgDUARQ9nHOghf9E8YdAg1vLA==", "+00000001", true, null, false, "InitialAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "Admin" });
        }
    }
}
