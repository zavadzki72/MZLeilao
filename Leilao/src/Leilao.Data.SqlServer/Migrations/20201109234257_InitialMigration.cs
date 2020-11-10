using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Data.SqlServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dta_creation = table.Column<DateTime>(nullable: false),
                    dta_update = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dta_creation = table.Column<DateTime>(nullable: false),
                    dta_update = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    dta_birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dta_creation = table.Column<DateTime>(nullable: false),
                    dta_update = table.Column<DateTime>(nullable: false),
                    price_offer = table.Column<decimal>(nullable: false),
                    qtde_bids = table.Column<int>(nullable: false),
                    dta_start = table.Column<DateTime>(nullable: false),
                    dta_end = table.Column<DateTime>(nullable: false),
                    is_over = table.Column<bool>(nullable: false),
                    id_product = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    id_user = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bid_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bid_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ProductId",
                table: "Bid",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserId",
                table: "Bid",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
