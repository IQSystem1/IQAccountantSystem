using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_imageId1",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_VIDEO_VIDEO_videoId1",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VIDEO",
                table: "VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_VIDEO",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_VIDEO_videoId1",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_IMAGE_imageId1",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT",
                table: "PRODUCT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IMAGE",
                table: "IMAGE");

            migrationBuilder.DropColumn(
                name: "VIDEO_ID",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "PRODUCT_VIDEO_ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "videoId1",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "PRODUCT_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "imageId1",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "PRODUCT_ID",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "IMAGE_ID",
                table: "IMAGE");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "VIDEO",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ADDED_DATA",
                table: "VIDEO",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP_ADDRESS",
                table: "VIDEO",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODEFIED_DATA",
                table: "VIDEO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PRODUCT_VIDEO",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ADDED_DATA",
                table: "PRODUCT_VIDEO",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP_ADDRESS",
                table: "PRODUCT_VIDEO",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODEFIED_DATA",
                table: "PRODUCT_VIDEO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PRODUCT_IMAGE",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ADDED_DATA",
                table: "PRODUCT_IMAGE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP_ADDRESS",
                table: "PRODUCT_IMAGE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODEFIED_DATA",
                table: "PRODUCT_IMAGE",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PRODUCT",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ADDED_DATA",
                table: "PRODUCT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP_ADDRESS",
                table: "PRODUCT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODEFIED_DATA",
                table: "PRODUCT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PRODUCT_NAME",
                table: "PRODUCT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "IMAGE",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ADDED_DATA",
                table: "IMAGE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP_ADDRESS",
                table: "IMAGE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODEFIED_DATA",
                table: "IMAGE",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VIDEO",
                table: "VIDEO",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_VIDEO",
                table: "PRODUCT_VIDEO",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT",
                table: "PRODUCT",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IMAGE",
                table: "IMAGE",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(nullable: false),
                    MODEFIED_DATA = table.Column<DateTime>(nullable: true),
                    IP_ADDRESS = table.Column<string>(nullable: true),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    QYANTITY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_sales_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_VIDEO_ID",
                table: "PRODUCT_VIDEO",
                column: "VIDEO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                column: "IMAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_sales_PRODUCT_ID",
                table: "sales",
                column: "PRODUCT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                column: "IMAGE_ID",
                principalTable: "IMAGE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_VIDEO",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_VIDEO_VIDEO_VIDEO_ID",
                table: "PRODUCT_VIDEO",
                column: "VIDEO_ID",
                principalTable: "VIDEO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_VIDEO_VIDEO_VIDEO_ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VIDEO",
                table: "VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_VIDEO",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_VIDEO_VIDEO_ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT",
                table: "PRODUCT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IMAGE",
                table: "IMAGE");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "ADDED_DATA",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "IP_ADDRESS",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "MODEFIED_DATA",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "ADDED_DATA",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "IP_ADDRESS",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "MODEFIED_DATA",
                table: "PRODUCT_VIDEO");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "ADDED_DATA",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "IP_ADDRESS",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "MODEFIED_DATA",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "ADDED_DATA",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "IP_ADDRESS",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "MODEFIED_DATA",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "PRODUCT_NAME",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "IMAGE");

            migrationBuilder.DropColumn(
                name: "ADDED_DATA",
                table: "IMAGE");

            migrationBuilder.DropColumn(
                name: "IP_ADDRESS",
                table: "IMAGE");

            migrationBuilder.DropColumn(
                name: "MODEFIED_DATA",
                table: "IMAGE");

            migrationBuilder.AddColumn<string>(
                name: "VIDEO_ID",
                table: "VIDEO",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PRODUCT_VIDEO_ID",
                table: "PRODUCT_VIDEO",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "videoId1",
                table: "PRODUCT_VIDEO",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRODUCT_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "imageId1",
                table: "PRODUCT_IMAGE",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PRODUCT_ID",
                table: "PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_ID",
                table: "IMAGE",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VIDEO",
                table: "VIDEO",
                column: "VIDEO_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_VIDEO",
                table: "PRODUCT_VIDEO",
                column: "PRODUCT_VIDEO_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_IMAGE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT",
                table: "PRODUCT",
                column: "PRODUCT_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IMAGE",
                table: "IMAGE",
                column: "IMAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VIDEO_videoId1",
                table: "PRODUCT_VIDEO",
                column: "videoId1");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGE_imageId1",
                table: "PRODUCT_IMAGE",
                column: "imageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_imageId1",
                table: "PRODUCT_IMAGE",
                column: "imageId1",
                principalTable: "IMAGE",
                principalColumn: "IMAGE_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "PRODUCT_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_VIDEO",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "PRODUCT_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_VIDEO_VIDEO_videoId1",
                table: "PRODUCT_VIDEO",
                column: "videoId1",
                principalTable: "VIDEO",
                principalColumn: "VIDEO_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
