using Microsoft.EntityFrameworkCore.Migrations;

namespace ODZ.Data.Migrations
{
    public partial class ChangeDocumentModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "Documents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Documents",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
