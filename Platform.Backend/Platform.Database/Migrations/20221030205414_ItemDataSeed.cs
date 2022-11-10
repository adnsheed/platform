using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    public partial class ItemDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SelectionId", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 6, 0, new DateTime(1968, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "8318022c-c549-48d2-a0b9-1cc672e11b91", "Student", null, false, "Zgembo", "Adislic", false, null, null, null, "AQAAAAEAACcQAAAAEAgLYPGf+6dq+/hVZnuXHofvTEY4nwi/Y5Xnm72Gvecf2WKoPYXRcmQot0MxboyS+w==", null, false, null, null, 3, false, "zgembo" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name", "Type", "Urls", "WorkHours" },
                values: new object[,]
                {
                    { 1, "Dive in and learn React.js from scratch! Learn Reactjs, Hooks, Redux, React Routing, Animations, Next.js and way more!", "React - The Complete Guide", 0, "https://reactjs.org/", 40 },
                    { 2, "Build the back-end of a .NET 6 web application with Web API, Entity Framework Core & SQL Server in no time!", ".Net Core API", 0, "https://dotnet.microsoft.com/en-us/", 20 },
                    { 3, "Learn how to start building, shipping, and maintaining software with GitHub.", "Git - Crash Course", 0, "https://docs.github.com/en", 0 },
                    { 4, "Send completed assignment to mentor", ".Net Core & React Test Project - Task", 1, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ItemPrograms",
                columns: new[] { "Id", "ItemId", "OrderNumber", "ProgramId" },
                values: new object[,]
                {
                    { 1, 1, 1, new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4") },
                    { 2, 2, 2, new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4") },
                    { 3, 3, 3, new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4") },
                    { 4, 4, 4, new Guid("79e9872d-5a2f-413e-ac36-511036ccd3d4") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemPrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemPrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemPrograms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemPrograms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

        }
    }
}
