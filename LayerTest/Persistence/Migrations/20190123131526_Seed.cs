using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLayer.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Service",
                table: "Creators",
                columns: new[] { "CreatorID", "CreatorName" },
                values: new object[] { 1, "Putin" });

            migrationBuilder.InsertData(
                schema: "Service",
                table: "Books",
                columns: new[] { "BookID", "BookName", "CreatorID", "Description", "Price" },
                values: new object[] { 1, "Venäjä", 1, "Kertoo venäjästä", "3000 rub" });

            migrationBuilder.InsertData(
                schema: "Service",
                table: "Movies",
                columns: new[] { "MovieID", "CreatorID", "Description", "MovieName", "Price" },
                values: new object[] { 1, 1, "Suosittelen", "Venäjä the movie", "4000 rub" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Creators",
                keyColumn: "CreatorID",
                keyValue: 1);
        }
    }
}
