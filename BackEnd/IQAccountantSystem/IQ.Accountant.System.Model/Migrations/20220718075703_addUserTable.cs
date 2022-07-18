using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQ.Accountant.System.Model.Migrations
{
    public partial class addUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_DATA = table.Column<DateTime>(nullable: false),
                    MODEFIED_DATA = table.Column<DateTime>(nullable: true),
                    IP_ADDRESS = table.Column<string>(nullable: true),
                    USER_NAME = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true),
                    IMAGE_ID = table.Column<int>(nullable: false),
                    ImageVideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_IMAGE_VIDEO_ImageVideoId",
                        column: x => x.ImageVideoId,
                        principalTable: "IMAGE_VIDEO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_ImageVideoId",
                table: "USER",
                column: "ImageVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_USER_NAME",
                table: "USER",
                column: "USER_NAME",
                unique: true,
                filter: "[USER_NAME] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
