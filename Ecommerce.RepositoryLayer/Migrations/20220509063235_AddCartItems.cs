using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class AddCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_cart_cartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_products_productId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "cartitems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_productId",
                table: "cartitems",
                newName: "IX_cartitems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_cartId",
                table: "cartitems",
                newName: "IX_cartitems_cartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartitems",
                table: "cartitems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_cartitems_cart_cartId",
                table: "cartitems",
                column: "cartId",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cartitems_products_productId",
                table: "cartitems",
                column: "productId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartitems_cart_cartId",
                table: "cartitems");

            migrationBuilder.DropForeignKey(
                name: "FK_cartitems_products_productId",
                table: "cartitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartitems",
                table: "cartitems");

            migrationBuilder.RenameTable(
                name: "cartitems",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_cartitems_productId",
                table: "CartItems",
                newName: "IX_CartItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_cartitems_cartId",
                table: "CartItems",
                newName: "IX_CartItems_cartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_cart_cartId",
                table: "CartItems",
                column: "cartId",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_products_productId",
                table: "CartItems",
                column: "productId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
