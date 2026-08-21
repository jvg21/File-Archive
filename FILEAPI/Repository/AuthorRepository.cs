using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FILEAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {   
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) {
            this._context = context;
        }

        public async Task<List<Author>> GetAll() { 
        
            return await _context.Author.AsNoTracking().Include(a=>a.URLS).ToListAsync();
        }

        public async Task<Author?> GetById(int id) {
            return await _context.Author.Include(a => a.URLS).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Author>> Get(Expression<Func<Author, bool>> predicate)
        {
            return await _context.Author.Where(predicate).Include(a => a.URLS).ToListAsync();
        }

        public async Task<bool> Exists(Expression<Func<Author, bool>> predicate)
        {
            return await _context.Author.AsNoTracking().AnyAsync(predicate);
        }

        public async Task<Author> Insert(Author author) { 
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author) {
            _context.Author.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task Delete(Author author)
        {
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
        }

    }
}
