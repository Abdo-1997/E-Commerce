using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class crt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_cart_products",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_products",
                table: "products");

            migrationBuilder.DropColumn(
                name: "products",
                table: "products");

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    cartid = table.Column<int>(type: "int", nullable: false),
                    productsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.cartid, x.productsid });
                    table.ForeignKey(
                        name: "FK_CartProduct_cart_cartid",
                        column: x => x.cartid,
                        principalTable: "cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_products_productsid",
                        column: x => x.productsid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_productsid",
                table: "CartProduct",
                column: "productsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.AddColumn<int>(
                name: "products",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_products",
                table: "products",
                column: "products");

            migrationBuilder.AddForeignKey(
                name: "FK_products_cart_products",
                table: "products",
                column: "products",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
