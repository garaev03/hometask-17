using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask_17.Migrations
{
    public partial class EditedWorkProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "WorkProducts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "WorkProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "WorkProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkImages_WorkProducts_WorkProductId",
                        column: x => x.WorkProductId,
                        principalTable: "WorkProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkImages_WorkProductId",
                table: "WorkImages",
                column: "WorkProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkImages");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "WorkProducts");

            migrationBuilder.DropColumn(
                name: "Quote",
                table: "WorkProducts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "WorkProducts",
                newName: "Path");
        }
    }
}
