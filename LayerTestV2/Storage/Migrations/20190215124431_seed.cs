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
                values: new object[] { 1, "Test Tester", "Test", "", "Tester", "1218810217245841120812815456141201909791" });

            migrationBuilder.InsertData(
                schema: "Service",
                table: "Customer",
                columns: new[] { "CustomerID", "Displayname", "FirstName", "ImgFilePath", "LastName", "Password" },
                values: new object[] { 2, "Test2 Tester2", "Test2", "", "Tester2", "1968485458221393622451008116401355443" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2);
        }
    }
}
