using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Data.SqlServer.Migrations
{
    public partial class RemoveItemsBid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dta_end",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "is_over",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "qtde_bids",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "dta_start",
                table: "Bid");

            migrationBuilder.AddColumn<bool>(
                name: "is_supered",
                table: "Bid",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_supered",
                table: "Bid");

            migrationBuilder.AddColumn<DateTime>(
                name: "dta_end",
                table: "Bid",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_over",
                table: "Bid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "qtde_bids",
                table: "Bid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dta_start",
                table: "Bid",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
