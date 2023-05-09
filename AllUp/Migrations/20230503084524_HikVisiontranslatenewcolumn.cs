using Microsoft.EntityFrameworkCore.Migrations;

namespace AllUp.Migrations
{
    public partial class HikVisiontranslatenewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardSubTitle",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardTitle",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderSubtitle",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderTitle",
                table: "Translate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardSubTitle",
                table: "Translate");

            migrationBuilder.DropColumn(
                name: "CardTitle",
                table: "Translate");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Translate");

            migrationBuilder.DropColumn(
                name: "HeaderSubtitle",
                table: "Translate");

            migrationBuilder.DropColumn(
                name: "HeaderTitle",
                table: "Translate");
        }
    }
}
