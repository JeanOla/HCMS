using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class fixdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25b76fb6-7ac0-4364-bb5d-9763a2903f29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33074dfc-6822-42d7-85c4-d05ea72aa7ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd469dba-8451-48e3-b600-03d0e839e45e");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "diabetic",
                table: "medicalRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "medicalLicenseNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointmentDay",
                table: "appointments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                values: new object[,]
                {
                    { "5c965850-234a-4d90-9c24-024ebfac6f20", "acb97ac7-1443-4744-8a54-b7a0ad5167cf", "Doctor", "DOCTOR" },
                    { "fb63abec-98f5-448e-8f56-302fafd16df4", "a9bf343b-fbe6-4caa-93e0-65019cf22dfe", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "medicalLicenseNumber", "middleName", "specialityId" },
                values: new object[] { "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae", 0, "766d002d-abf5-4139-8ed9-2d95ce07ac8a", "adminjuan@gmail.com", false, "Male", false, null, "ADMINJUAN@GMAIL.COM", "ADMINJUAN@GMAIL.COM", "AQAAAAEAACcQAAAAEOGwxNiS16aj5gtKMaYUr/+fmF7utY7a1q+cCwfNOOoyORGRend6ecL1uDiAQth+6A==", "09191231231", false, "03e9225a-3cd7-442f-93f0-3c01f727c166", false, "adminjuan@gmail.com", "Sta. Rosa, Laguna", new DateTime(2023, 4, 24, 18, 45, 15, 982, DateTimeKind.Local).AddTicks(8067), "Juan", "Cruz", null, "Dela", null });

            migrationBuilder.UpdateData(
                table: "medicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "diabetic",
                value: "Yes");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2023, 4, 24, 18, 45, 15, 984, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb63abec-98f5-448e-8f56-302fafd16df4", "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae" });

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
                keyValue: "5c965850-234a-4d90-9c24-024ebfac6f20");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb63abec-98f5-448e-8f56-302fafd16df4", "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb63abec-98f5-448e-8f56-302fafd16df4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae");

            migrationBuilder.DropColumn(
                name: "dob",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "medicalLicenseNumber",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<bool>(
                name: "diabetic",
                table: "medicalRecords",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "appointmentDay",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
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
                values: new object[,]
                {
                    { "25b76fb6-7ac0-4364-bb5d-9763a2903f29", "9551cb6c-e10b-4bc2-b686-13ae5d6eee51", "Admin", "ADMIN" },
                    { "33074dfc-6822-42d7-85c4-d05ea72aa7ab", "561c7e93-b96f-42b5-af8e-32087dd89e58", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "fd469dba-8451-48e3-b600-03d0e839e45e", 0, "3af1cb88-0d73-4b8d-856c-7380ed7a2b88", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "61a0284e-20f6-4a28-b24c-da01f98e7f35", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 4, 19, 32, 51, 965, DateTimeKind.Local).AddTicks(3410), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.UpdateData(
                table: "medicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "diabetic",
                value: false);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
