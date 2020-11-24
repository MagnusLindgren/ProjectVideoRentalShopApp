using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseConnection.Migrations
{
    public partial class MemberGotUserNameKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Members_RentedById",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentedById",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "RentedById",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "RentedByUsername",
                table: "Rentals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Members",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentedByUsername",
                table: "Rentals",
                column: "RentedByUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Members_RentedByUsername",
                table: "Rentals",
                column: "RentedByUsername",
                principalTable: "Members",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Members_RentedByUsername",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentedByUsername",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "RentedByUsername",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "RentedById",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentedById",
                table: "Rentals",
                column: "RentedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Members_RentedById",
                table: "Rentals",
                column: "RentedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
