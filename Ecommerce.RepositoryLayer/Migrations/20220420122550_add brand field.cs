using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.RepositoryLayer.Migrations
{
    public partial class addbrandfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "brandname",
                table: "products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brandname",
                table: "products");
        }
    }
}
