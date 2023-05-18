using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class addCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE addCase
            @patientId INT,
            @diagnosis NVARCHAR(MAX),
            @treatmentPlan NVARCHAR(50),
            @reason NVARCHAR(MAX)
              
            AS
            BEGIN
               INSERT INTO cases (patientId, diagnosis, reason, treatmentPlan) VALUES (@patientId, @diagnosis, @reason, @treatmentPlan);
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = "DROP PROCEDURE addCase";
            migrationBuilder.Sql(sp);
        }
    }
}
