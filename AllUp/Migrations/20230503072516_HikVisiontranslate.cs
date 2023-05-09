using Microsoft.EntityFrameworkCore.Migrations;

namespace AllUp.Migrations
{
    public partial class HikVisiontranslate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AzerbaijanLanguage",
                table: "Translate",
                newName: "Englishlanguage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Englishlanguage",
                table: "Translate",
                newName: "AzerbaijanLanguage");
        }
    }
}
