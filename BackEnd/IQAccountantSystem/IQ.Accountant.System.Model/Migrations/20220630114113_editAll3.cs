using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class editAll3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropTable(
                name: "IMAGE");

            migrationBuilder.DropTable(
                name: "PRODUCT_VIDEO");

            migrationBuilder.DropTable(
                name: "VIDEO");

            migrationBuilder.AddColumn<bool>(
                name: "IS_IMAGE",
                table: "PRODUCT_IMAGE",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "IMAGE_VIDEO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(nullable: false),
                    MODEFIED_DATA = table.Column<DateTime>(nullable: true),
                    IP_ADDRESS = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGE_VIDEO", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                column: "IMAGE_ID",
                principalTable: "IMAGE_VIDEO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropTable(
                name: "IMAGE_VIDEO");

            migrationBuilder.DropColumn(
                name: "IS_IMAGE",
                table: "PRODUCT_IMAGE");

            migrationBuilder.CreateTable(
                name: "IMAGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODEFIED_DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VIDEO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODEFIED_DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDEO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VIDEO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODEFIED_DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    VIDEO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VIDEO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VIDEO_VIDEO_VIDEO_ID",
                        column: x => x.VIDEO_ID,
                        principalTable: "VIDEO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_PRODUCT_ID",
                table: "PRODUCT_VIDEO",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_VIDEO_ID",
                table: "PRODUCT_VIDEO",
                column: "VIDEO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                column: "IMAGE_ID",
                principalTable: "IMAGE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
