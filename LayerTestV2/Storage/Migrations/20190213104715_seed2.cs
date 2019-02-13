using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Service",
                table: "Customer",
                columns: new[] { "CustomerID", "Displayname", "FirstName", "ImgFilePath", "LastName", "Password" },
                values: new object[] { 2, "Test2 Tester2", "Test2", "", "Tester2", "Test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2);
        }
    }
}
