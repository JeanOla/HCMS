using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d3a0d2-613b-4cc7-9832-f1dfb4c811d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca716172-faf2-4be9-b5da-9cdd3f905cae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7ee90e0-e8ec-40c7-926f-6a49469c11ec");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5d3a0d2-613b-4cc7-9832-f1dfb4c811d5", "65210d5a-9261-44a5-abce-de97891322ee", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca716172-faf2-4be9-b5da-9cdd3f905cae", "c7d062ee-5226-4fb5-97ad-439dd9bc5dfb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "b7ee90e0-e8ec-40c7-926f-6a49469c11ec", 0, "ab6681d4-8455-469b-ba57-41516b96fd66", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "30193e5d-5ac1-461e-8b20-f13bd6b021d4", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 3, 22, 17, 16, 510, DateTimeKind.Local).AddTicks(9923), "Juan", "Cruz", "Dela", 1 });
        }
    }
}
