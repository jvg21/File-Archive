using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FILEAPI.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Book>> GetAll()
        {

            return await _context.Book.AsNoTracking().Include(b=>b.URLS).ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Book.Include(b => b.URLS).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Book>> Get(Expression<Func<Book, bool>> predicate)
        {
            return await _context.Book.Where(predicate).ToListAsync();
        }

        public async Task<bool> Exists(Expression<Func<Book, bool>> predicate)
        {
            return await _context.Book.AsNoTracking().AnyAsync(predicate);
        }

        public async Task<Book> Insert(Book book)
        {
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Book.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(Book book)
        {
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
