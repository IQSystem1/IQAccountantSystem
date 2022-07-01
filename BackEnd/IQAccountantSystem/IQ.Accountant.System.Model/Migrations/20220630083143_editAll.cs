using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class editAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_PRODUCT_IQ_CODE",
                table: "PRODUCT");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_IQ_CODE",
                table: "PRODUCT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_IQ_CODE",
                table: "PRODUCT",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRODUCT_IQ_CODE",
                table: "PRODUCT",
                column: "PRODUCT_IQ_CODE",
                unique: true,
                filter: "[PRODUCT_IQ_CODE] IS NOT NULL");
        }
    }
}
