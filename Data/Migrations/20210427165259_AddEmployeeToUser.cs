using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddEmployeeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeAdresse",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCountry",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeePostalCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeAdresse",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeePostalCode",
                table: "AspNetUsers");
        }
    }
}
