using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILEAPI.Migrations
{
    /// <inheritdoc />
    public partial class Book_atributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentChapter",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "book",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "book",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadingStatus",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "book",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalChapters",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Words",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WritingStatus",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentChapter",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "book");

            migrationBuilder.DropColumn(
                name: "ReadingStatus",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "book");

            migrationBuilder.DropColumn(
                name: "TotalChapters",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Words",
                table: "book");

            migrationBuilder.DropColumn(
                name: "WritingStatus",
                table: "book");
        }
    }
}
