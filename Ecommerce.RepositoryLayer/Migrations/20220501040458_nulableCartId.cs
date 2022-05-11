using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class nulableCartId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cart_cartid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cartid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "cartid",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cartid",
                table: "AspNetUsers",
                column: "cartid",
                unique: true,
                filter: "[cartid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cart_cartid",
                table: "AspNetUsers",
                column: "cartid",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cart_cartid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cartid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "cartid",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cartid",
                table: "AspNetUsers",
                column: "cartid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cart_cartid",
                table: "AspNetUsers",
                column: "cartid",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
