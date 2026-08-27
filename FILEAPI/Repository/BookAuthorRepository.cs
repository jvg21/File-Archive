using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FILEAPI.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly AppDbContext _context;
        public BookAuthorRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Exists(BookAuthor bookAuthor)
        {
            return await _context.BookAuthor.AnyAsync(ba=>ba.IdBook == bookAuthor.IdBook && ba.IdAuthor == bookAuthor.IdAuthor);
        }

        public async Task LinkBookToAuthor(BookAuthor bookAuthor)
        {
            await _context.BookAuthor.AddAsync(bookAuthor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLinkBookToAuthor(BookAuthor bookAuthor)
        {

            _context.BookAuthor.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }

    }
}
