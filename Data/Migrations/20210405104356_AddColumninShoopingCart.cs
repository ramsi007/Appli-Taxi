using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddColumninShoopingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponCodeDiscount",
                table: "Proposals");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShooppingCarts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShooppingCarts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Remise",
                table: "ShooppingCarts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "ShooppingCarts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShooppingCarts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShooppingCarts");

            migrationBuilder.DropColumn(
                name: "Remise",
                table: "ShooppingCarts");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "ShooppingCarts");

            migrationBuilder.AddColumn<double>(
                name: "CouponCodeDiscount",
                table: "Proposals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
