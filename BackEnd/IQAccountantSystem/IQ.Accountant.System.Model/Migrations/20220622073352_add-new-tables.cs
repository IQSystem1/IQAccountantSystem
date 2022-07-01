using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class addnewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRODUCT_QUANTITY",
                table: "PRODUCT");

            migrationBuilder.CreateTable(
                name: "VIDEO",
                columns: table => new
                {
                    VIDEO_ID = table.Column<string>(nullable: false),
                    VIDEO_URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDEO", x => x.VIDEO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VIDEO",
                columns: table => new
                {
                    PRODUCT_VIDEO_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIDEO_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    videoId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VIDEO", x => x.PRODUCT_VIDEO_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VIDEO_VIDEO_videoId1",
                        column: x => x.videoId1,
                        principalTable: "VIDEO",
                        principalColumn: "VIDEO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_PRODUCT_ID",
                table: "PRODUCT_VIDEO",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_videoId1",
                table: "PRODUCT_VIDEO",
                column: "videoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_VIDEO");

            migrationBuilder.DropTable(
                name: "VIDEO");

            migrationBuilder.AddColumn<float>(
                name: "PRODUCT_QUANTITY",
                table: "PRODUCT",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
