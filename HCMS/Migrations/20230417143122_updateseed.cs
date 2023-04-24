using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c965850-234a-4d90-9c24-024ebfac6f20",
                column: "ConcurrencyStamp",
                value: "e9feb22e-8264-4b76-b9ac-55a362d2b6de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb63abec-98f5-448e-8f56-302fafd16df4",
                column: "ConcurrencyStamp",
                value: "b2363851-ee5e-499e-9bae-6e37abaa2d87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8f8a7dac-ae70-44e6-8c39-4f6d72e07ea5", "adminjuan@gmail.com", "ADMINJUAN@GMAIL.COM", "ADMINJUAN@GMAIL.COM", "AQAAAAEAACcQAAAAEPpwMvr4Rchr3u6nA3vgieT6iabJQbfj2I+UDwykhB/TDVHadz+C3I81kJHAheHPGA==", "16a1fe2b-7ae3-4405-b7b7-5733195de312", "adminjuan@gmail.com" });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2023, 4, 17, 22, 31, 21, 574, DateTimeKind.Local).AddTicks(722));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c965850-234a-4d90-9c24-024ebfac6f20",
                column: "ConcurrencyStamp",
                value: "542f2501-a04e-41a2-8030-285f9fb1eebf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb63abec-98f5-448e-8f56-302fafd16df4",
                column: "ConcurrencyStamp",
                value: "82c20e6f-151d-4733-9507-e90569f1f0ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "dcd6d016-a37d-455a-afbc-6233064d75c3", "juandelacruz@gmail.com", null, null, "AQAAAAEAACcQAAAAEABWpaHz2YzIcPLrxi0rL7+HtVUomMFXIzx4cG70nbeFaYmT/OlhCy7ERXY22QwDig==", "e868c960-c918-4015-8d0f-b924e02d8076", "juandelacruz@gmail.com" });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "dob",
                value: new DateTime(2023, 4, 17, 22, 24, 42, 973, DateTimeKind.Local).AddTicks(3367));
        }
    }
}
