using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILEAPI.Migrations
{
    /// <inheritdoc />
    public partial class isactivecontroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "url",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "filearchive",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "book",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "author",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "url");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "filearchive");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "book");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "author");
        }
    }
}
