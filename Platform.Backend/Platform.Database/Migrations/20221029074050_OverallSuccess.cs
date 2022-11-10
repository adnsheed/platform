using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    public partial class OverallSuccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var create = @"CREATE PROCEDURE [dbo].[OverallSuccess] 
            AS 
            BEGIN 
            SET 
            nocount on; 
            SELECT 
	            (SELECT COUNT(*) FROM AspNetUsers WHERE status = 1) /
		            CAST(COUNT(Status) AS FLOAT) * 100 AS OverallSuccessRate
            FROM AspNetUsers
            END;";

            migrationBuilder.Sql(create);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var drop = "DROP PROCEDURE [dbo].[OverallSuccess] ";

            migrationBuilder.Sql(drop);
        }
    }
}