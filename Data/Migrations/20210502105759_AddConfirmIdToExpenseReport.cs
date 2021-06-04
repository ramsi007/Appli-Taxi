using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddConfirmIdToExpenseReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmId",
                table: "ExpenseReports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmId",
                table: "ExpenseReports");
        }
    }
}
