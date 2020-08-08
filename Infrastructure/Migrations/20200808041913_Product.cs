using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Security",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                schema: "Security",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Security",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                schema: "Security",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                schema: "Security",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                schema: "Security",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                schema: "Security",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                schema: "Security",
                table: "Products",
                column: "ProductBrandId",
                principalSchema: "Security",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                schema: "Security",
                table: "Products",
                column: "ProductTypeId",
                principalSchema: "Security",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrands",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "Security");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBrandId",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                schema: "Security",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                schema: "Security",
                table: "Products");
        }
    }
}
