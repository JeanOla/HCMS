using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "420163c5-b71a-4bfc-8175-12f8683a36f9", "56717379-315d-417a-a287-56565d53bb21", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de6c1bc7-6d58-4aa7-a216-8e6937260c60", "63cfcba7-efcd-47f5-9d2b-7dde3d9ff529", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Email", "address", "firstName", "gender", "lastName", "middleName", "phone" },
                values: new object[] { 1, "ljolaguer@email.com", "Cabuyao, Laguna", "Lhener Jean", "Male", "Olaguer", "Rareza", "09504645926" });

            migrationBuilder.InsertData(
                table: "medicalRecords",
                columns: new[] { "Id", "allergy", "bloodType", "diabetic", "medication", "patientId", "surgery", "vacinated" },
                values: new object[] { 1, null, "A+", false, null, 1, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "420163c5-b71a-4bfc-8175-12f8683a36f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de6c1bc7-6d58-4aa7-a216-8e6937260c60");

            migrationBuilder.DeleteData(
                table: "medicalRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
