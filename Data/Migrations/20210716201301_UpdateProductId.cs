using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_taxi.Data.Migrations
{
    public partial class UpdateProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "ProposalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "BillDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "ProposalDetails");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "BillDetails");
        }
    }
}
