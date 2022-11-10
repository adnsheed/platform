using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    public partial class SelectionSuccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createSql = @"CREATE PROCEDURE [dbo].[SelectionsSuccess] 
            AS 
            BEGIN 
            SET 
            nocount on; 
            SELECT 
                selections.Id AS Id, 
                selections.Title AS SelectionTitle, 
                programs.Title AS ProgramTitle, 
	            (SELECT COUNT(*) FROM AspNetUsers WHERE status = 1 AND selections.Id = AspNetUsers.SelectionId ) / 
	                CAST(COUNT(AspNetUsers.Status) AS FLOAT) * 100 AS SuccessRate
            FROM selections JOIN programs 
            ON selections.ProgramId = programs.Id 
            JOIN AspNetUsers 
            ON selections.Id = AspNetUsers.SelectionId 
            GROUP BY selections.Id, selections.Title, programs.Title 
            END;";

            migrationBuilder.Sql(createSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSql = "DROP PROCEDURE [dbo].[SelectionsSuccess] ";

            migrationBuilder.Sql(dropSql);
        }
    }
}