using Microsoft.EntityFrameworkCore.Migrations;

namespace AllUp.Migrations
{
    public partial class HikVisiontranslatenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Englishlanguage",
                table: "Translate");

            migrationBuilder.RenameColumn(
                name: "RussianLanguage",
                table: "Translate",
                newName: "language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "language",
                table: "Translate",
                newName: "RussianLanguage");

            migrationBuilder.AddColumn<string>(
                name: "Englishlanguage",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
