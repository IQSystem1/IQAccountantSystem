using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IMAGE",
                columns: table => new
                {
                    IMAGE_ID = table.Column<string>(nullable: false),
                    IMAGE_URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGE", x => x.IMAGE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_CODE = table.Column<string>(nullable: false),
                    PRODUCT_QUANTITY = table.Column<float>(nullable: false),
                    PRODUCT_UNIT = table.Column<string>(nullable: false),
                    PRODUCT_PRICE = table.Column<float>(nullable: false),
                    PRODUCT_TAX = table.Column<float>(nullable: true),
                    PRODUCT_SHIPPING = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_IMAGE",
                columns: table => new
                {
                    PRODUCT_IMAGE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    imageId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_IMAGE", x => x.PRODUCT_IMAGE_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IMAGE_IMAGE_imageId1",
                        column: x => x.imageId1,
                        principalTable: "IMAGE",
                        principalColumn: "IMAGE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRODUCT_CODE",
                table: "PRODUCT",
                column: "PRODUCT_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGE_imageId1",
                table: "PRODUCT_IMAGE",
                column: "imageId1");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGE_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_IMAGE");

            migrationBuilder.DropTable(
                name: "IMAGE");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
