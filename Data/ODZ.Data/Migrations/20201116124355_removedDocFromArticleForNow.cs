using Microsoft.EntityFrameworkCore.Migrations;

namespace ODZ.Data.Migrations
{
    public partial class removedDocFromArticleForNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Documents_DocumentId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_DocumentId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DocumentId",
                table: "Articles",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Documents_DocumentId",
                table: "Articles",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
