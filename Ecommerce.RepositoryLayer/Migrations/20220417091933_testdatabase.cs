using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class testdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "maincats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maincats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pictures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    picture1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    picture2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    picture3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    picture4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supcats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supcats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    sellername = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maincategoryid = table.Column<int>(type: "int", nullable: false),
                    supcategoryid = table.Column<int>(type: "int", nullable: false),
                    picturesid = table.Column<int>(type: "int", nullable: false),
                    maincatid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_maincats_maincatid",
                        column: x => x.maincatid,
                        principalTable: "maincats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_pictures_picturesid",
                        column: x => x.picturesid,
                        principalTable: "pictures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_products_maincatid",
                table: "products",
                column: "maincatid");

            migrationBuilder.CreateIndex(
                name: "IX_products_picturesid",
                table: "products",
                column: "picturesid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productsupcat_supcatsid",
                table: "Productsupcat",
                column: "supcatsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productsupcat");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "supcats");

            migrationBuilder.DropTable(
                name: "maincats");

            migrationBuilder.DropTable(
                name: "pictures");
        }
    }
}
