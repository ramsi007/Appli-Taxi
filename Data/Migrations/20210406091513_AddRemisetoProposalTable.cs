using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddRemisetoProposalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Remise",
                table: "Proposals",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remise",
                table: "Proposals");
        }
    }
}
