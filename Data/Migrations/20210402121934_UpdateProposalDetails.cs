using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class UpdateProposalDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalDetails_Proposals_ProposalId",
                table: "ProposalDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProposalDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
                table: "ProposalDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalDetails_Proposals_ProposalId",
                table: "ProposalDetails",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalDetails_Proposals_ProposalId",
                table: "ProposalDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
                table: "ProposalDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProposalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalDetails_Proposals_ProposalId",
                table: "ProposalDetails",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
