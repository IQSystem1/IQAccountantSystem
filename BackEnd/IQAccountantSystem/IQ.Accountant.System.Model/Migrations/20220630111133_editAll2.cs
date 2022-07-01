using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class editAll2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIDEO_URL",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "IMAGE_URL",
                table: "IMAGE");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "VIDEO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "IMAGE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "VIDEO");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "IMAGE");

            migrationBuilder.AddColumn<string>(
                name: "VIDEO_URL",
                table: "VIDEO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_URL",
                table: "IMAGE",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
