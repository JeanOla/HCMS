using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class scheduleTimeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3d15f2c-2096-450c-a51a-fe6ffa14a2f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c54d9e67-7a8c-48f2-b4b6-fbda7da3b779");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e19dda69-bcc7-4680-9d1f-9c2af8a74c91");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3d15f2c-2096-450c-a51a-fe6ffa14a2f6", "cfb4ad5e-20ac-41d8-8de6-0f727b0ef08e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c54d9e67-7a8c-48f2-b4b6-fbda7da3b779", "e5f8f501-c45d-4dde-9fbe-8348c9423e25", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "e19dda69-bcc7-4680-9d1f-9c2af8a74c91", 0, "5b2746e2-ffb5-4a28-bd6b-59810efd7d3e", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "10663999-52e8-42b2-8123-f7185473df63", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 2, 23, 15, 52, 670, DateTimeKind.Local).AddTicks(1880), "Juan", "Cruz", "Dela", 1 });
        }
    }
}
