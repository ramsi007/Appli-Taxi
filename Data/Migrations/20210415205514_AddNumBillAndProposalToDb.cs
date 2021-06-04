using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddNumBillAndProposalToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "NumBill",
                table: "ShooppingCarts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumProposal",
                table: "ShooppingCarts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumBill",
                table: "ShooppingCarts");

            migrationBuilder.DropColumn(
                name: "NumProposal",
                table: "ShooppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "ShooppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProposalId",
                table: "ShooppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
