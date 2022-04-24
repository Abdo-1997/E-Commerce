using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_pictures_picturesid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_picturesid",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "supcategoryid",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "picturesid",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "maincategoryid",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_products_picturesid",
                table: "products",
                column: "picturesid",
                unique: true,
                filter: "[picturesid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_products_pictures_picturesid",
                table: "products",
                column: "picturesid",
                principalTable: "pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_pictures_picturesid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_picturesid",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "supcategoryid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "picturesid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "maincategoryid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_picturesid",
                table: "products",
                column: "picturesid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_pictures_picturesid",
                table: "products",
                column: "picturesid",
                principalTable: "pictures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
