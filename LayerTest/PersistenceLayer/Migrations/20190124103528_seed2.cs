using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLayer.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Service",
                table: "Books",
                columns: new[] { "BookID", "BookName", "CreatorID", "Description", "Price" },
                values: new object[] { 2, "Russia", 1, "Mother Russia", "6000 rub" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);
        }
    }
}
