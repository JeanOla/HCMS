using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCMS.Migrations
{
    public partial class deleteCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE deleteCase
          
            @Id INT
              
            AS
            BEGIN
              Delete FROM cases WHERE Id = @Id;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = "DROP PROCEDURE deleteCase";
            migrationBuilder.Sql(sp);
        }
    }
}
