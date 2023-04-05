using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class nullableDoctorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4057c472-bb54-4a22-841c-9973068154f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711d5285-1fba-4002-9535-a8a642f1a0fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8239db4f-2e32-4c1f-97b2-21ae8c5bb0b6");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4057c472-bb54-4a22-841c-9973068154f3", "740689a1-29a8-434a-95a4-76020b43f6ad", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "711d5285-1fba-4002-9535-a8a642f1a0fa", "e7666c0b-e3e6-4c39-b778-97d2c77a45cf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "8239db4f-2e32-4c1f-97b2-21ae8c5bb0b6", 0, "a8fcc8ef-454d-4553-af21-342cd7a1ffa4", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "a9381670-2275-470f-a8d8-9f8e8e46328a", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 4, 19, 16, 13, 612, DateTimeKind.Local).AddTicks(8910), "Juan", "Cruz", "Dela", 1 });
        }
    }
}
