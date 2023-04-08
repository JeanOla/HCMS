using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class addDOBinPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "dob",
                table: "patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12e7161e-90d8-4e34-92f0-cea651a212f1", "e8fb8ff7-4b2d-4d99-8dab-d5ebdd12e6b1", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc83e1a2-a6e9-4e26-8068-868e01d191f4", "815e777e-004e-4458-9995-ae9ebcb246d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "db20b0b2-f283-42c0-b4d8-36b7357ea65f", 0, "a17022a0-2298-4db0-9bae-0ab3d3389475", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "89501f69-3a9d-43ab-940a-14e0ee848492", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 7, 19, 33, 12, 72, DateTimeKind.Local).AddTicks(9934), "Juan", "Cruz", "Dela", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12e7161e-90d8-4e34-92f0-cea651a212f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc83e1a2-a6e9-4e26-8068-868e01d191f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db20b0b2-f283-42c0-b4d8-36b7357ea65f");

            migrationBuilder.DropColumn(
                name: "dob",
                table: "patients");

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
        }
    }
}
