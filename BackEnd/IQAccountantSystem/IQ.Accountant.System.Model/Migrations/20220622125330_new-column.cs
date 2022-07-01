using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class newcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_PRODUCT_PRODUCT_ID",
                table: "sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sales",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "PRODUCT_SHIPPING",
                table: "PRODUCT");

            migrationBuilder.RenameTable(
                name: "sales",
                newName: "SALE");

            migrationBuilder.RenameIndex(
                name: "IX_sales_PRODUCT_ID",
                table: "SALE",
                newName: "IX_SALE_PRODUCT_ID");

            migrationBuilder.AddColumn<string>(
                name: "PRODUCT_NOTE",
                table: "PRODUCT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SALE",
                table: "SALE",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SALE_PRODUCT_PRODUCT_ID",
                table: "SALE",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SALE_PRODUCT_PRODUCT_ID",
                table: "SALE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SALE",
                table: "SALE");

            migrationBuilder.DropColumn(
                name: "PRODUCT_NOTE",
                table: "PRODUCT");

            migrationBuilder.RenameTable(
                name: "SALE",
                newName: "sales");

            migrationBuilder.RenameIndex(
                name: "IX_SALE_PRODUCT_ID",
                table: "sales",
                newName: "IX_sales_PRODUCT_ID");

            migrationBuilder.AddColumn<float>(
                name: "PRODUCT_SHIPPING",
                table: "PRODUCT",
                type: "real",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sales",
                table: "sales",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_PRODUCT_PRODUCT_ID",
                table: "sales",
                column: "PRODUCT_ID",
                principalTable: "PRODUCT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
