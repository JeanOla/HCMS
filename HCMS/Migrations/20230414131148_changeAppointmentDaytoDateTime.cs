using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class changeAppointmentDaytoDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "appointmentDay",
                table: "appointments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed5765ab-8ac8-420a-b933-2ce2aee02e87", "d18436d4-8f26-4c50-bb8b-aa4c6372c02d", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb3d0817-3476-4eaf-a27e-2e11c1ec2464", "ac057691-e998-49e3-b211-d199107ce09f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "39ebbe9f-7d1e-454b-b30e-9eaa3ca03bdf", 0, "afa6d500-a274-426d-a196-1f6194f20c5e", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "247385b0-178f-4dd7-98a5-3a7a6e5a8f1b", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 14, 21, 11, 47, 552, DateTimeKind.Local).AddTicks(7922), "Juan", "Cruz", "Dela", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5765ab-8ac8-420a-b933-2ce2aee02e87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb3d0817-3476-4eaf-a27e-2e11c1ec2464");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39ebbe9f-7d1e-454b-b30e-9eaa3ca03bdf");

            migrationBuilder.AlterColumn<string>(
                name: "appointmentDay",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }
    }
}
