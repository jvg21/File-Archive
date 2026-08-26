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

        public async Task<bool> Exists(BookAuthor bookAuthor)
        {
            return await _context.Author.Where(a => a.Id == bookAuthor.IdAuthor).SelectMany(a => a.Books).AnyAsync(b => b.Id == bookAuthor.IdBook);
        }

        public async Task LinkBookToAuthor(BookAuthor bookAuthor)
        {
            var book = new Book { Id = bookAuthor.IdBook };
            var author = new Author { Id = bookAuthor.IdAuthor };

            _context.Attach(book);
            _context.Attach(author);

            book.Authors.Add(author);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLinkBookToAuthor(BookAuthor bookAuthor)
        {

            var book = await _context.Book
                .Include(b => b.Authors.Where(a => a.Id == bookAuthor.IdAuthor))
                .FirstOrDefaultAsync(b => b.Id == bookAuthor.IdBook);

            if (book == null) return;

            var author = book.Authors.FirstOrDefault(a => a.Id == bookAuthor.IdAuthor);
            if (author != null)
            {
                book.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

    }
}
