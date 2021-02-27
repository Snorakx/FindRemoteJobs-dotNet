using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetProject.Migrations
{
    public partial class FavouriteJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFavouriteJob",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouriteJob", x => new { x.JobId, x.UserId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavouriteJob");
        }
    }
}
