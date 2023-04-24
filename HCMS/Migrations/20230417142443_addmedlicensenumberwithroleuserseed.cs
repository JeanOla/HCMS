using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class addmedlicensenumberwithroleuserseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "medicalLicenseNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c965850-234a-4d90-9c24-024ebfac6f20", "542f2501-a04e-41a2-8030-285f9fb1eebf", "Doctor", "DOCTOR" },
                    { "fb63abec-98f5-448e-8f56-302fafd16df4", "82c20e6f-151d-4733-9507-e90569f1f0ce", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "medicalLicenseNumber", "middleName", "specialityId" },
                values: new object[] { "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae", 0, "dcd6d016-a37d-455a-afbc-6233064d75c3", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "AQAAAAEAACcQAAAAEABWpaHz2YzIcPLrxi0rL7+HtVUomMFXIzx4cG70nbeFaYmT/OlhCy7ERXY22QwDig==", "09191231231", false, "e868c960-c918-4015-8d0f-b924e02d8076", false, "juandelacruz@gmail.com", "Sta. Rosa, Laguna", null, "Juan", "Cruz", null, "Dela", null });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2023, 4, 17, 22, 24, 42, 973, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb63abec-98f5-448e-8f56-302fafd16df4", "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "medicalLicenseNumber",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "patients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ed5765ab-8ac8-420a-b933-2ce2aee02e87", "d18436d4-8f26-4c50-bb8b-aa4c6372c02d", "Doctor", "DOCTOR" },
                    { "fb3d0817-3476-4eaf-a27e-2e11c1ec2464", "ac057691-e998-49e3-b211-d199107ce09f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "39ebbe9f-7d1e-454b-b30e-9eaa3ca03bdf", 0, "afa6d500-a274-426d-a196-1f6194f20c5e", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "247385b0-178f-4dd7-98a5-3a7a6e5a8f1b", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 14, 21, 11, 47, 552, DateTimeKind.Local).AddTicks(7922), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "dob",
                value: null);
        }
    }
}
