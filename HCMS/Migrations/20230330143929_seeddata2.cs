using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class seeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "420163c5-b71a-4bfc-8175-12f8683a36f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de6c1bc7-6d58-4aa7-a216-8e6937260c60");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e1bebdc-253f-4cc4-8610-622073bf6df6", "d93a2257-f0f7-4c4b-9206-ce9b07b719e9", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e40e1d53-9343-4bc6-b50a-608047f4b693", "e2abc354-db63-4ad7-92aa-644954897f7f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "specialities",
                columns: new[] { "Id", "SpecialityName" },
                values: new object[] { 1, "Neurology" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "3fb37b25-a10e-49db-b2d8-e680d497dd98", 0, "d8f61600-2675-4987-9937-5b86dd3b4c90", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "25429dfe-82c6-4d50-a023-489ab5ff904d", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 3, 30, 22, 39, 29, 356, DateTimeKind.Local).AddTicks(9413), "Juan", "Cruz", "Dela", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e1bebdc-253f-4cc4-8610-622073bf6df6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40e1d53-9343-4bc6-b50a-608047f4b693");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fb37b25-a10e-49db-b2d8-e680d497dd98");

            migrationBuilder.DeleteData(
                table: "specialities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "420163c5-b71a-4bfc-8175-12f8683a36f9", "56717379-315d-417a-a287-56565d53bb21", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de6c1bc7-6d58-4aa7-a216-8e6937260c60", "63cfcba7-efcd-47f5-9d2b-7dde3d9ff529", "Doctor", "DOCTOR" });
        }
    }
}
