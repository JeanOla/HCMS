using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_cases_caseId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_caseId",
                table: "appointments");

            migrationBuilder.AddColumn<int>(
                name: "casesId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_casesId",
                table: "appointments",
                column: "casesId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_cases_casesId",
                table: "appointments",
                column: "casesId",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_cases_casesId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_casesId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "casesId",
                table: "appointments");

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
        }
    }
}
