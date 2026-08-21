using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FILEAPI.Migrations
{
    /// <inheritdoc />
    public partial class Book_url_relashionships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book_Author",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "integer", nullable: false),
                    BooksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Author", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_Book_Author_author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Author_book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "url",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Book_Id = table.Column<int>(type: "integer", nullable: true),
                    Author_Id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url", x => x.Id);
                    table.ForeignKey(
                        name: "FK_url_author_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_url_book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_Name",
                table: "author",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_Name",
                table: "book",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Author_BooksId",
                table: "Book_Author",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_url_Author_Id",
                table: "url",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_url_Book_Id",
                table: "url",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_url_Content",
                table: "url",
                column: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Author");

            migrationBuilder.DropTable(
                name: "url");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropIndex(
                name: "IX_author_Name",
                table: "author");
        }
    }
}
