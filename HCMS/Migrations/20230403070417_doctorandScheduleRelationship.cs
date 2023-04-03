using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class doctorandScheduleRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9852e5f5-c15e-4f8e-86fd-3c787d5fd3ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ba463f-e22b-43b3-a4a9-1617a0aea270");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "810693a9-bf87-442f-a2c0-a8687bb755b6");

            migrationBuilder.AlterColumn<string>(
                name: "doctorId",
                table: "schedules",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83a71b0e-d0a4-43fa-9d5f-b2d486536018", "d8a66713-b955-4c08-b80d-a52c12c0a215", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1d5c11d-eac3-487a-9f62-02c8a2ec3844", "e00b5826-aa68-4596-97cf-dae61ab9ef46", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "7864d171-3676-4024-9004-b8d6f3d7d35f", 0, "6db786cd-c3f7-40df-bce8-937633b5e62e", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "6c99fd11-e114-461d-9206-9a9be1ea696a", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 3, 15, 4, 16, 446, DateTimeKind.Local).AddTicks(3623), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_schedules_doctorId",
                table: "schedules",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_AspNetUsers_doctorId",
                table: "schedules",
                column: "doctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_AspNetUsers_doctorId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_doctorId",
                table: "schedules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83a71b0e-d0a4-43fa-9d5f-b2d486536018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d5c11d-eac3-487a-9f62-02c8a2ec3844");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7864d171-3676-4024-9004-b8d6f3d7d35f");

            migrationBuilder.AlterColumn<int>(
                name: "doctorId",
                table: "schedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9852e5f5-c15e-4f8e-86fd-3c787d5fd3ba", "3eee7590-a113-40a0-8d5e-03295621bebf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3ba463f-e22b-43b3-a4a9-1617a0aea270", "062b65c0-3d71-439e-9013-7acde040dd9f", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "810693a9-bf87-442f-a2c0-a8687bb755b6", 0, "5789517e-11ca-4d51-b758-fbf1db01bff4", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "1cfd5b43-1e5c-40d0-9a9b-8eea1b34a98e", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 3, 14, 23, 10, 664, DateTimeKind.Local).AddTicks(1092), "Juan", "Cruz", "Dela", 1 });
        }
    }
}
