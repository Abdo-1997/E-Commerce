using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_maincats_maincatid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_supcats_supcatid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_maincatid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_supcatid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "maincatid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "supcatid",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_maincategoryid",
                table: "products",
                column: "maincategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_products_supcategoryid",
                table: "products",
                column: "supcategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_maincats_maincategoryid",
                table: "products",
                column: "maincategoryid",
                principalTable: "maincats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_supcats_supcategoryid",
                table: "products",
                column: "supcategoryid",
                principalTable: "supcats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_maincats_maincategoryid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_supcats_supcategoryid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_maincategoryid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_supcategoryid",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "maincatid",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "supcatid",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_maincatid",
                table: "products",
                column: "maincatid");

            migrationBuilder.CreateIndex(
                name: "IX_products_supcatid",
                table: "products",
                column: "supcatid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_maincats_maincatid",
                table: "products",
                column: "maincatid",
                principalTable: "maincats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_supcats_supcatid",
                table: "products",
                column: "supcatid",
                principalTable: "supcats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
