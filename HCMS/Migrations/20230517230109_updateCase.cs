using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class updateCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE updateCase
            @patientId INT,
            @diagnosis NVARCHAR(MAX),
            @treatmentPlan NVARCHAR(50),
            @reason NVARCHAR(MAX),
            @Id INT
              
            AS
            BEGIN
               UPDATE cases
                SET patientId = @patientId,
                    diagnosis = @diagnosis,
                    treatmentPlan = @treatmentPlan,
                    reason = @reason
                WHERE Id = @Id;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = "DROP PROCEDURE updateCase";
            migrationBuilder.Sql(sp);
        }
    }
}
