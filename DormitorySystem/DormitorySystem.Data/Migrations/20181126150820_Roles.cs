using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a5422d94-abb6-4de6-91d5-ad49a67b767d", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a5422d94-abb6-4de6-91d5-ad49a67b767d", "bd70add0-cb47-4cb2-9735-46a1eaa24d7e" });

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "d6f5709f-c631-4410-9e61-d9caf6f3e43b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "cd812e70-9a27-49a1-baf3-68b34a647a78");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "586b32ca-e81c-4e45-9efe-d15acf7872e1", 0, "4d2573dd-7ff9-4a83-b3ef-68cd1369a5f0", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAEHKosX5g+xEdPuh3ED4df1ppyiVd4nPuJgPmawB/s3Crcyi+8CZR7rx/vOxkejPaGg==", "+00000001", true, "c6b64da6-d1d2-4a14-aac4-32b6ac70892e", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "26.11.2018 г. 17:08:17");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "UserId1" },
                values: new object[] { "586b32ca-e81c-4e45-9efe-d15acf7872e1", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "586b32ca-e81c-4e45-9efe-d15acf7872e1", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "586b32ca-e81c-4e45-9efe-d15acf7872e1", "4d2573dd-7ff9-4a83-b3ef-68cd1369a5f0" });

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "73f9b64b-8bc3-409d-99c9-87f57ead2e64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User",
                column: "ConcurrencyStamp",
                value: "a56e9ff7-0b21-4e23-a9ab-6aa04167dc81");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "GDPR", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isDeleted" },
                values: new object[] { "a5422d94-abb6-4de6-91d5-ad49a67b767d", 0, "bd70add0-cb47-4cb2-9735-46a1eaa24d7e", null, null, "InitialAdmin@system.com", true, false, false, null, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN@SYSTEM.COM", "AQAAAAEAACcQAAAAENirXDriI3t1WKM2yBThD3s9rmT+IG3MUe+D7oiAWbUH/xYazlquv0vLxpNo2Q8Zbg==", "+00000001", true, "4507e27d-2421-4909-b184-d30a5929bcba", false, "InitialAdmin", false });

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("08503c1c-963f-4106-9088-82fa67d34f9d"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("1f0ef0ff-396b-40cb-ac3d-749196dee187"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("216fc1e7-1496-4532-b9ee-29565b865ad6"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("61ff0614-64fd-4842-9a05-0b1541d2cc61"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("65d98ff7-b524-49de-8d13-f85753d98858"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("7a3b1db5-959d-46ce-82b6-517773327427"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("81a2e1b1-ea5d-4356-8266-b6b42471653e"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("92f7dc9a-f2fe-4b60-82f5-400e42f099b4"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("a3b8a078-0409-4365-ace6-6f8b5b93d592"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("ec3c4770-5d57-4d81-9c83-a02140b883a1"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.UpdateData(
                table: "SampleSensors",
                keyColumn: "Id",
                keyValue: new Guid("f1796a28-642e-401f-8129-fd7465417061"),
                column: "TimeStamp",
                value: "25.11.2018 г. 18:04:14");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a5422d94-abb6-4de6-91d5-ad49a67b767d", "Admin" });
        }
    }
}
