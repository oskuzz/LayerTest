using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Service",
                table: "Customer",
                columns: new[] { "CustomerID", "Displayname", "FirstName", "ImgFilePath", "LastName", "Password" },
                values: new object[] { 1, "Test Tester", "Test", "", "Tester", "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1);
        }
    }
}
