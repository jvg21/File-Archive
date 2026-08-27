using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILEAPI.Migrations
{
    /// <inheritdoc />
    public partial class PromoteBookAuthorToEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_author_AuthorsId",
                table: "Book_Author");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_book_BooksId",
                table: "Book_Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author");

            migrationBuilder.RenameTable(
                name: "Book_Author",
                newName: "book_author");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "book_author",
                newName: "IdAuthor");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "book_author",
                newName: "IdBook");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Author_BooksId",
                table: "book_author",
                newName: "IX_book_author_IdAuthor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_author",
                table: "book_author",
                columns: new[] { "IdBook", "IdAuthor" });

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_author_IdAuthor",
                table: "book_author",
                column: "IdAuthor",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_author_book_IdBook",
                table: "book_author",
                column: "IdBook",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_author_author_IdAuthor",
                table: "book_author");

            migrationBuilder.DropForeignKey(
                name: "FK_book_author_book_IdBook",
                table: "book_author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_author",
                table: "book_author");

            migrationBuilder.RenameTable(
                name: "book_author",
                newName: "Book_Author");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Book_Author",
                newName: "BooksId");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Book_Author",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_book_author_IdAuthor",
                table: "Book_Author",
                newName: "IX_Book_Author_BooksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_Author",
                table: "Book_Author",
                columns: new[] { "AuthorsId", "BooksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_author_AuthorsId",
                table: "Book_Author",
                column: "AuthorsId",
                principalTable: "author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_book_BooksId",
                table: "Book_Author",
                column: "BooksId",
                principalTable: "book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
