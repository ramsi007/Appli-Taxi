using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class UpdateProposalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "OrderTotalOrginal",
                table: "Proposals");

            migrationBuilder.AddColumn<string>(
                name: "PoposalType",
                table: "Proposals",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProposalTotal",
                table: "Proposals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProposalTotalOrginal",
                table: "Proposals",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoposalType",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ProposalTotal",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ProposalTotalOrginal",
                table: "Proposals");

            migrationBuilder.AddColumn<double>(
                name: "OrderTotal",
                table: "Proposals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OrderTotalOrginal",
                table: "Proposals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
