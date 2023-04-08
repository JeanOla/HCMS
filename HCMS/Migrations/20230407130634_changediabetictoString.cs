using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class changediabetictoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "diabetic",
                table: "medicalRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2600e38e-f337-440a-972c-024104af8eef", "132570ea-1a58-45ea-98d9-102bc51ead51", "Doctor", "DOCTOR" },
                    { "9d255e0d-796a-41e1-b1bf-4707e16b5a0e", "87a17628-2819-46d5-9c25-a6357734d9eb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "9c9d7666-99f0-45e7-9b39-092b24878af2", 0, "6babcc17-09d3-4ca6-9d27-408a7202434a", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "ae80ee9b-c6b7-4c26-b846-3da78973343f", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 7, 21, 6, 33, 678, DateTimeKind.Local).AddTicks(857), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.UpdateData(
                table: "medicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "diabetic",
                value: "Yes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<bool>(
                name: "diabetic",
                table: "medicalRecords",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12e7161e-90d8-4e34-92f0-cea651a212f1", "e8fb8ff7-4b2d-4d99-8dab-d5ebdd12e6b1", "Doctor", "DOCTOR" },
                    { "dc83e1a2-a6e9-4e26-8068-868e01d191f4", "815e777e-004e-4458-9995-ae9ebcb246d3", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "db20b0b2-f283-42c0-b4d8-36b7357ea65f", 0, "a17022a0-2298-4db0-9bae-0ab3d3389475", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "89501f69-3a9d-43ab-940a-14e0ee848492", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 7, 19, 33, 12, 72, DateTimeKind.Local).AddTicks(9934), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.UpdateData(
                table: "medicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "diabetic",
                value: false);
        }
    }
}
