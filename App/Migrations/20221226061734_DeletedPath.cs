using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask_17.Migrations
{
    public partial class DeletedPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "WorkImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "WorkImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "WorkImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "WorkImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
