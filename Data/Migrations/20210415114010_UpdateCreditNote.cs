﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli_Taxi.Data.Migrations
{
    public partial class UpdateCreditNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CreditNotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_UserId",
                table: "CreditNotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNotes_AspNetUsers_UserId",
                table: "CreditNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditNotes_AspNetUsers_UserId",
                table: "CreditNotes");

            migrationBuilder.DropIndex(
                name: "IX_CreditNotes_UserId",
                table: "CreditNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CreditNotes");
        }
    }
}
