using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_taxi.Data.Migrations
{
    public partial class UpdateBillAndProposalDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Produits_ProduitId",
                table: "BillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalDetails_Produits_ProduitId",
                table: "ProposalDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProposalDetails_ProduitId",
                table: "ProposalDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_ProduitId",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "ProposalDetails");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "BillDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "ProposalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProposalDetails_ProduitId",
                table: "ProposalDetails",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ProduitId",
                table: "BillDetails",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Produits_ProduitId",
                table: "BillDetails",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalDetails_Produits_ProduitId",
                table: "ProposalDetails",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
