using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Migrations
{
    public partial class deletefildestoplace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Place",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_UserId",
                table: "Place",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_AspNetUsers_UserId",
                table: "Place",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_AspNetUsers_UserId",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_UserId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Place");
        }
    }
}
