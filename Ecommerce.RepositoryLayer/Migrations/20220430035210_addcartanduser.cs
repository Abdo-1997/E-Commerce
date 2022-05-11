using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class addcartanduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cartid",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cart_cartid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cartid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cartid",
                table: "AspNetUsers");
        }
    }
}
