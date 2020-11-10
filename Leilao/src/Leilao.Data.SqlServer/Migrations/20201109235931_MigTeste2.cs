using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Data.SqlServer.Migrations
{
    public partial class MigTeste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Product_ProductId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_User_UserId",
                table: "Bid");

            migrationBuilder.DropIndex(
                name: "IX_Bid_ProductId",
                table: "Bid");

            migrationBuilder.DropIndex(
                name: "IX_Bid_UserId",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bid");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_IdProduct",
                table: "Bid",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_IdUser",
                table: "Bid",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Product_IdProduct",
                table: "Bid",
                column: "IdProduct",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_User_IdUser",
                table: "Bid",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Product_IdProduct",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_User_IdUser",
                table: "Bid");

            migrationBuilder.DropIndex(
                name: "IX_Bid_IdProduct",
                table: "Bid");

            migrationBuilder.DropIndex(
                name: "IX_Bid_IdUser",
                table: "Bid");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Bid",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Bid",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ProductId",
                table: "Bid",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserId",
                table: "Bid",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Product_ProductId",
                table: "Bid",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_User_UserId",
                table: "Bid",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
