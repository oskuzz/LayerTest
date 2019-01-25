using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLayer.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Service",
                table: "Movies",
                columns: new[] { "MovieID", "CreatorID", "Description", "MovieName", "Price" },
                values: new object[] { 2, 1, "Hyi", "The Indian TechSubbord", "1000 €" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2);
        }
    }
}
