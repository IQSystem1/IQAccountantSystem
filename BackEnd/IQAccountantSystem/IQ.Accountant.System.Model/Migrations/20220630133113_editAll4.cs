using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class editAll4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE");

            migrationBuilder.RenameTable(
                name: "PRODUCT_IMAGE",
                newName: "PRODUCT_IMAGE_VIDEO");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_IMAGE_PRODUCT_ID",
                table: "PRODUCT_IMAGE_VIDEO",
                newName: "IX_PRODUCT_IMAGE_VIDEO_PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_IMAGE_IMAGE_ID",
                table: "PRODUCT_IMAGE_VIDEO",
                newName: "IX_PRODUCT_IMAGE_VIDEO_IMAGE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_IMAGE_VIDEO",
                table: "PRODUCT_IMAGE_VIDEO",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_VIDEO_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE_VIDEO",
                column: "IMAGE_ID",
                principalTable: "IMAGE_VIDEO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE_VIDEO",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_VIDEO_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE_VIDEO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_IMAGE_VIDEO_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE_VIDEO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT_IMAGE_VIDEO",
                table: "PRODUCT_IMAGE_VIDEO");

            migrationBuilder.RenameTable(
                name: "PRODUCT_IMAGE_VIDEO",
                newName: "PRODUCT_IMAGE");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_IMAGE_VIDEO_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                newName: "IX_PRODUCT_IMAGE_PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                newName: "IX_PRODUCT_IMAGE_IMAGE_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT_IMAGE",
                table: "PRODUCT_IMAGE",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_IMAGE_VIDEO_IMAGE_ID",
                table: "PRODUCT_IMAGE",
                column: "IMAGE_ID",
                principalTable: "IMAGE_VIDEO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
