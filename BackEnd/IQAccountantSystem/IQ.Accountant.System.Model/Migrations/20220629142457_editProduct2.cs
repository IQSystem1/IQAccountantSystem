using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class editProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_PRODUCT_CODE",
                table: "PRODUCT");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                table: "PRODUCT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PRODUCT_IQ_CODE",
                table: "PRODUCT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRODUCT_IQ_CODE",
                table: "PRODUCT",
                column: "PRODUCT_IQ_CODE",
                unique: true,
                filter: "[PRODUCT_IQ_CODE] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_PRODUCT_IQ_CODE",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "PRODUCT_IQ_CODE",
                table: "PRODUCT");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                table: "PRODUCT",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRODUCT_CODE",
                table: "PRODUCT",
                column: "PRODUCT_CODE",
                unique: true);
        }
    }
}
