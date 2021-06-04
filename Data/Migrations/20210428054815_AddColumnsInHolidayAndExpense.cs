using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class AddColumnsInHolidayAndExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Holidays",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DemandeDate",
                table: "Holidays",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Nbdays",
                table: "Holidays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Holidays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ExpenseReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "DemandeDate",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "Nbdays",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExpenseReports");
        }
    }
}
