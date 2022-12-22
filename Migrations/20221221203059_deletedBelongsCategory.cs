using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask_17.Migrations
{
    public partial class deletedBelongsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BelongsTo",
                table: "WorkCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BelongsTo",
                table: "WorkCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
