using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseConnection.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rentals_RentalId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RentalId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MoviesId",
                table: "Rentals",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Movies_MoviesId",
                table: "Rentals",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Movies_MoviesId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_MoviesId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RentalId",
                table: "Movies",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rentals_RentalId",
                table: "Movies",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
