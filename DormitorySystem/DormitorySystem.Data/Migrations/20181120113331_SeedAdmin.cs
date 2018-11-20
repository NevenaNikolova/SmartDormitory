using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DormitorySystem.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensor_Measure_MeasureId",
                table: "SampleSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensor_Type_TypeId",
                table: "SampleSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSensor_SampleSensor_SampleSensorId",
                table: "UserSensor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSensor_AspNetUsers_UserId",
                table: "UserSensor");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSensor",
                table: "UserSensor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleSensor",
                table: "SampleSensor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measure",
                table: "Measure");

            migrationBuilder.RenameTable(
                name: "UserSensor",
                newName: "UserSensors");

            migrationBuilder.RenameTable(
                name: "SampleSensor",
                newName: "SampleSensors");

            migrationBuilder.RenameTable(
                name: "Measure",
                newName: "Measures");

            migrationBuilder.RenameIndex(
                name: "IX_UserSensor_UserId",
                table: "UserSensors",
                newName: "IX_UserSensors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSensor_SampleSensorId",
                table: "UserSensors",
                newName: "IX_UserSensors_SampleSensorId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensor_TypeId",
                table: "SampleSensors",
                newName: "IX_SampleSensors_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensor_MeasureId",
                table: "SampleSensors",
                newName: "IX_SampleSensors_MeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSensors",
                table: "UserSensors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleSensors",
                table: "SampleSensors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measures",
                table: "Measures",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "Admin", "5fb87322-cbea-44bf-9de7-171ff00775b7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "User", "730a0b98-3190-475e-b960-6f82a508b15e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", 0, "e0f32e9e-ce99-426b-a570-39a32d19537a", "InitialAdmin@system.com", true, false, null, "INITIALADMIN@SYSTEM.COM", "INITIALADMIN", "AQAAAAEAACcQAAAAEOLs/53maxska07LVxI03pZcI6KW8b9+qwRHDIF3wsgDUARQ9nHOghf9E8YdAg1vLA==", "+00000001", true, null, false, "InitialAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensors_Measures_MeasureId",
                table: "SampleSensors",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensors_Types_TypeId",
                table: "SampleSensors",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensors_SampleSensors_SampleSensorId",
                table: "UserSensors",
                column: "SampleSensorId",
                principalTable: "SampleSensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId",
                table: "UserSensors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensors_Measures_MeasureId",
                table: "SampleSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleSensors_Types_TypeId",
                table: "SampleSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSensors_SampleSensors_SampleSensorId",
                table: "UserSensors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSensors_AspNetUsers_UserId",
                table: "UserSensors");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSensors",
                table: "UserSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleSensors",
                table: "SampleSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measures",
                table: "Measures");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "User", "730a0b98-3190-475e-b960-6f82a508b15e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "Admin" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "Admin", "5fb87322-cbea-44bf-9de7-171ff00775b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d06d05f0-4e2b-45d4-aea7-7fb07315facd", "e0f32e9e-ce99-426b-a570-39a32d19537a" });

            migrationBuilder.RenameTable(
                name: "UserSensors",
                newName: "UserSensor");

            migrationBuilder.RenameTable(
                name: "SampleSensors",
                newName: "SampleSensor");

            migrationBuilder.RenameTable(
                name: "Measures",
                newName: "Measure");

            migrationBuilder.RenameIndex(
                name: "IX_UserSensors_UserId",
                table: "UserSensor",
                newName: "IX_UserSensor_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSensors_SampleSensorId",
                table: "UserSensor",
                newName: "IX_UserSensor_SampleSensorId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensors_TypeId",
                table: "SampleSensor",
                newName: "IX_SampleSensor_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleSensors_MeasureId",
                table: "SampleSensor",
                newName: "IX_SampleSensor_MeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSensor",
                table: "UserSensor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleSensor",
                table: "SampleSensor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measure",
                table: "Measure",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensor_Measure_MeasureId",
                table: "SampleSensor",
                column: "MeasureId",
                principalTable: "Measure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleSensor_Type_TypeId",
                table: "SampleSensor",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensor_SampleSensor_SampleSensorId",
                table: "UserSensor",
                column: "SampleSensorId",
                principalTable: "SampleSensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSensor_AspNetUsers_UserId",
                table: "UserSensor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
