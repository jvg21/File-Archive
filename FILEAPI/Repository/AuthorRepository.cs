using LifeSafeAPI.Data.Database;
using LifeSafeAPI.Data.Models;
using LifeSafeAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeSafeAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {   
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) {
            this._context = context;
        }

        public async Task<List<AuthorGetDTO>> GetAll() { 
        
            return await _context.Author.AsNoTracking().ToListAsync();
        }
    }
}
