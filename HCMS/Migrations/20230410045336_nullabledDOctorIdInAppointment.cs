using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class nullabledDOctorIdInAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2600e38e-f337-440a-972c-024104af8eef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d255e0d-796a-41e1-b1bf-4707e16b5a0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7666-99f0-45e7-9b39-092b24878af2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startTime",
                table: "schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a1eb1b7-2fde-47eb-879c-a04d3893c139", "a49fbc0d-b4ae-475b-bd2b-27314a4068f1", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f51c6366-da6c-496e-b3c7-929e0780c7ca", "3883b4fd-a0bb-4a12-8e94-c8e4b281f710", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "25dc3e74-d227-4125-8821-1faa000c5e4f", 0, "84f9c0bb-188e-4737-af18-c3caa6be23a2", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "584435c1-d38b-4548-b961-5e9d09df4b64", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 10, 12, 53, 35, 352, DateTimeKind.Local).AddTicks(5764), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a1eb1b7-2fde-47eb-879c-a04d3893c139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f51c6366-da6c-496e-b3c7-929e0780c7ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25dc3e74-d227-4125-8821-1faa000c5e4f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startTime",
                table: "schedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "endTime",
                table: "schedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2600e38e-f337-440a-972c-024104af8eef", "132570ea-1a58-45ea-98d9-102bc51ead51", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d255e0d-796a-41e1-b1bf-4707e16b5a0e", "87a17628-2819-46d5-9c25-a6357734d9eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "9c9d7666-99f0-45e7-9b39-092b24878af2", 0, "6babcc17-09d3-4ca6-9d27-408a7202434a", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "ae80ee9b-c6b7-4c26-b846-3da78973343f", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 7, 21, 6, 33, 678, DateTimeKind.Local).AddTicks(857), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
