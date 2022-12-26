using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask_17.Migrations
{
    public partial class MadeProductPublicInImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkImages_WorkProducts_WorkProductId",
                table: "WorkImages");

            migrationBuilder.DropIndex(
                name: "IX_WorkImages_WorkProductId",
                table: "WorkImages");

            migrationBuilder.DropColumn(
                name: "WorkProductId",
                table: "WorkImages");

            migrationBuilder.CreateIndex(
                name: "IX_WorkImages_ProductId",
                table: "WorkImages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkImages_WorkProducts_ProductId",
                table: "WorkImages",
                column: "ProductId",
                principalTable: "WorkProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkImages_WorkProducts_ProductId",
                table: "WorkImages");

            migrationBuilder.DropIndex(
                name: "IX_WorkImages_ProductId",
                table: "WorkImages");

            migrationBuilder.AddColumn<int>(
                name: "WorkProductId",
                table: "WorkImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkImages_WorkProductId",
                table: "WorkImages",
                column: "WorkProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkImages_WorkProducts_WorkProductId",
                table: "WorkImages",
                column: "WorkProductId",
                principalTable: "WorkProducts",
                principalColumn: "Id");
        }
    }
}
