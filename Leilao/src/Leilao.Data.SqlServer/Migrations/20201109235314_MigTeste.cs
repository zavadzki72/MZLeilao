using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Data.SqlServer.Migrations
{
    public partial class MigTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "Bid",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "id_product",
                table: "Bid",
                newName: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Bid",
                newName: "id_user");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Bid",
                newName: "id_product");
        }
    }
}
