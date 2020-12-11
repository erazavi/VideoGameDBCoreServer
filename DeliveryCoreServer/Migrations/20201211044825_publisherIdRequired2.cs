using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryCoreServer.Migrations
{
    public partial class publisherIdRequired2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_publishers",
                table: "videogames");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_publishers",
                table: "videogames",
                column: "publisher_id",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_publishers",
                table: "videogames");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_publishers",
                table: "videogames",
                column: "publisher_id",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
