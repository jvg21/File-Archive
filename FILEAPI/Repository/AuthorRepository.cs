using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FILEAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {   
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) {
            this._context = context;
        }

        public async Task<List<Author>> GetAll() { 
        
            return await _context.Author.AsNoTracking().ToListAsync();
        }

        public async Task<Author?> GetById(int id) {
            return await _context.Author.FindAsync(id);
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Author.AnyAsync(x=> x.Id == id);
        }

        public async Task<Author> Insert(Author author) { 
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task Update() {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Author author)
        {
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
        }

    }
}
