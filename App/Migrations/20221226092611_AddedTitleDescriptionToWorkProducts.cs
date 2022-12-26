using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask_17.Migrations
{
    public partial class AddedTitleDescriptionToWorkProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleDescription",
                table: "WorkProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleDescription",
                table: "WorkProducts");
        }
    }
}
