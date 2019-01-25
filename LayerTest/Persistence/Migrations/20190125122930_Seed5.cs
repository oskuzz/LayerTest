using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLayer.Migrations
{
    public partial class Seed5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                schema: "Service",
                table: "Customer",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "role",
                schema: "Service",
                table: "Customer",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "passWord",
                schema: "Service",
                table: "Customer",
                newName: "Password");

            migrationBuilder.InsertData(
                schema: "Service",
                table: "Customer",
                columns: new[] { "CustomerID", "Password", "Role", "UserName" },
                values: new object[] { 1, "Asd-123", "Admin", "Asd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Service",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "Service",
                table: "Customer",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "Service",
                table: "Customer",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "Service",
                table: "Customer",
                newName: "passWord");
        }
    }
}
