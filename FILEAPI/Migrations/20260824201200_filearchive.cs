using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FILEAPI.Migrations
{
    /// <inheritdoc />
    public partial class filearchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Words",
                table: "book",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "TotalChapters",
                table: "book",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentChapter",
                table: "book",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "filearchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StorageName = table.Column<string>(type: "text", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    MimeType = table.Column<string>(type: "text", nullable: true),
                    StorageBytes = table.Column<long>(type: "bigint", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Book_Id = table.Column<int>(type: "integer", nullable: true),
                    Author_Id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filearchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_filearchive_author_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_filearchive_book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "book",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_filearchive_Author_Id",
                table: "filearchive",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_filearchive_Book_Id",
                table: "filearchive",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filearchive");

            migrationBuilder.AlterColumn<int>(
                name: "Words",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalChapters",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentChapter",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
