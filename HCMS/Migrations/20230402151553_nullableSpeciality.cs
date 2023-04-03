using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class nullableSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_specialities_specialityId",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<int>(
                name: "specialityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_specialities_specialityId",
                table: "AspNetUsers",
                column: "specialityId",
                principalTable: "specialities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_specialities_specialityId",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<int>(
                name: "specialityId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e1bebdc-253f-4cc4-8610-622073bf6df6", "d93a2257-f0f7-4c4b-9206-ce9b07b719e9", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e40e1d53-9343-4bc6-b50a-608047f4b693", "e2abc354-db63-4ad7-92aa-644954897f7f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "3fb37b25-a10e-49db-b2d8-e680d497dd98", 0, "d8f61600-2675-4987-9937-5b86dd3b4c90", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "25429dfe-82c6-4d50-a023-489ab5ff904d", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 3, 30, 22, 39, 29, 356, DateTimeKind.Local).AddTicks(9413), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_specialities_specialityId",
                table: "AspNetUsers",
                column: "specialityId",
                principalTable: "specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
