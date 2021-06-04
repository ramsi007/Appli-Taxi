using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddTaxTableAndTaxIdInProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "Produits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_TaxId",
                table: "Produits",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Taxes_TaxId",
                table: "Produits",
                column: "TaxId",
                principalTable: "Taxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Taxes_TaxId",
                table: "Produits");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Produits_TaxId",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "Produits");
        }
    }
}
