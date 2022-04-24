using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class Editerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productsupcat");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "supcats");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "supcatid",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_supcatid",
                table: "products",
                column: "supcatid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_supcats_supcatid",
                table: "products",
                column: "supcatid",
                principalTable: "supcats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_supcats_supcatid",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_supcatid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "products");

            migrationBuilder.DropColumn(
                name: "supcatid",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "supcats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Productsupcat",
                columns: table => new
                {
                    productsid = table.Column<int>(type: "int", nullable: false),
                    supcatsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productsupcat", x => new { x.productsid, x.supcatsid });
                    table.ForeignKey(
                        name: "FK_Productsupcat_products_productsid",
                        column: x => x.productsid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productsupcat_supcats_supcatsid",
                        column: x => x.supcatsid,
                        principalTable: "supcats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productsupcat_supcatsid",
                table: "Productsupcat",
                column: "supcatsid");
        }
    }
}
