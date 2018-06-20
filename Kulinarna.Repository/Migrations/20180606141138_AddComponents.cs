using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class AddComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Components",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Components",
                table: "Recipes");
        }
    }
}
