using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class appointmentUserRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_UserId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_UserId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aba3e89e-0909-44c1-bb51-a6859b8700ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf211a0-d225-4e13-8510-03b3275ae7c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c43c4831-e055-4a00-bf86-1d185a5388a9");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "appointments");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25b76fb6-7ac0-4364-bb5d-9763a2903f29", "9551cb6c-e10b-4bc2-b686-13ae5d6eee51", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33074dfc-6822-42d7-85c4-d05ea72aa7ab", "561c7e93-b96f-42b5-af8e-32087dd89e58", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "fd469dba-8451-48e3-b600-03d0e839e45e", 0, "3af1cb88-0d73-4b8d-856c-7380ed7a2b88", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "61a0284e-20f6-4a28-b24c-da01f98e7f35", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 4, 19, 32, 51, 965, DateTimeKind.Local).AddTicks(3410), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_DoctorId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_DoctorId",
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

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aba3e89e-0909-44c1-bb51-a6859b8700ae", "c83c619d-f11b-43d3-9978-fd39b6d75d30", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caf211a0-d225-4e13-8510-03b3275ae7c1", "60914a50-20f1-44d8-a44b-4910964b6b40", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "c43c4831-e055-4a00-bf86-1d185a5388a9", 0, "04ad0575-a366-4803-87df-875652b76821", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "4cf99528-eb79-49f6-8a19-f2ec6a93c341", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 4, 19, 23, 13, 142, DateTimeKind.Local).AddTicks(153), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_UserId",
                table: "appointments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_UserId",
                table: "appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
