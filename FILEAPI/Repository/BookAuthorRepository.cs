using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FILEAPI.Repository
{
    public class BookAuthorRepository: IBookAuthorRepository
    {
        private readonly AppDbContext _context;
        public BookAuthorRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Exists(int idBook, int idAuthor)
        {
            return await _context.Author.Where(a => a.Id == idAuthor).SelectMany(a => a.Books).AnyAsync(b => b.Id == idBook);
        }

        public async Task LinkBookToAuthor(int idBook, int idAuthor)
        {
            var book = new Book { Id = idBook };
            var author = new Author { Id = idAuthor };

            _context.Attach(book);
            _context.Attach(author);

            book.Authors.Add(author);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLinkBookToAuthor(int idBook, int idAuthor)
        {

            var book = await _context.Book
                .Include(b => b.Authors.Where(a => a.Id == idAuthor))
                .FirstOrDefaultAsync(b => b.Id == idBook);

            if (book == null) return;

            var author = book.Authors.FirstOrDefault(a => a.Id == idAuthor);
            if (author != null)
            {
                book.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

    }
}
