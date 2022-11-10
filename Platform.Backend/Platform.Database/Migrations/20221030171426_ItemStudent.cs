using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    public partial class ItemStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "ItemStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ItemProgramId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProgressStatus = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Not Started")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStudent", x => new { x.ItemProgramId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ItemStudent_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStudent_ItemPrograms_ItemProgramId",
                        column: x => x.ItemProgramId,
                        principalTable: "ItemPrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemStudent_StudentId",
                table: "ItemStudent",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemStudent");
        }
    }
}
