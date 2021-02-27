using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetProject.Migrations
{
    public partial class FavouriteJobs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "UserFavouriteJob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserFavouriteJob",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "UserFavouriteJob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "UserFavouriteJob");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserFavouriteJob");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "UserFavouriteJob");
        }
    }
}
