using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class modifyDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_cases_casesId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_cases_medicalRecords_medicalRecordId",
                table: "cases");

            migrationBuilder.DropIndex(
                name: "IX_appointments_casesId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PatientId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83a71b0e-d0a4-43fa-9d5f-b2d486536018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d5c11d-eac3-487a-9f62-02c8a2ec3844");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7864d171-3676-4024-9004-b8d6f3d7d35f");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "medicalRecordId",
                table: "cases",
                newName: "patientId");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "cases",
                newName: "reason");

            migrationBuilder.RenameIndex(
                name: "IX_cases_medicalRecordId",
                table: "cases",
                newName: "IX_cases_patientId");

            migrationBuilder.RenameColumn(
                name: "appoinmentDate",
                table: "appointments",
                newName: "appointmentime");

            migrationBuilder.AlterColumn<string>(
                name: "diagnosis",
                table: "cases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "appointmentDay",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_appointments_caseId",
                table: "appointments",
                column: "caseId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_cases_caseId",
                table: "appointments",
                column: "caseId",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cases_patients_patientId",
                table: "cases",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_cases_caseId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_cases_patients_patientId",
                table: "cases");

            migrationBuilder.DropIndex(
                name: "IX_appointments_caseId",
                table: "appointments");

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

            migrationBuilder.DropColumn(
                name: "appointmentDay",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "cases",
                newName: "doctorId");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "cases",
                newName: "medicalRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_cases_patientId",
                table: "cases",
                newName: "IX_cases_medicalRecordId");

            migrationBuilder.RenameColumn(
                name: "appointmentime",
                table: "appointments",
                newName: "appoinmentDate");

            migrationBuilder.AlterColumn<string>(
                name: "diagnosis",
                table: "cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "casesId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83a71b0e-d0a4-43fa-9d5f-b2d486536018", "d8a66713-b955-4c08-b80d-a52c12c0a215", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1d5c11d-eac3-487a-9f62-02c8a2ec3844", "e00b5826-aa68-4596-97cf-dae61ab9ef46", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "dob", "firstName", "lastName", "middleName", "specialityId" },
                values: new object[] { "7864d171-3676-4024-9004-b8d6f3d7d35f", 0, "6db786cd-c3f7-40df-bce8-937633b5e62e", "juandelacruz@gmail.com", false, "Male", false, null, null, null, "juandelacruz123", "09191231231", false, "6c99fd11-e114-461d-9206-9a9be1ea696a", false, "juandc", "Sta. Rosa, Laguna", new DateTime(2023, 4, 3, 15, 4, 16, 446, DateTimeKind.Local).AddTicks(3623), "Juan", "Cruz", "Dela", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_casesId",
                table: "appointments",
                column: "casesId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_cases_casesId",
                table: "appointments",
                column: "casesId",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cases_medicalRecords_medicalRecordId",
                table: "cases",
                column: "medicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
