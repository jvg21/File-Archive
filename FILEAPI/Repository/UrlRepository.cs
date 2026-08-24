using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FILEAPI.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly AppDbContext _context;

        public UrlRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Url>> GetAll()
        {
            return await _context.Url.AsNoTracking().ToListAsync();
        }

        public async Task<Url?> GetById(int id)
        {
            return await _context.Url.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Url>> Get(Expression<Func<Url, bool>> predicate)
        {
            return await _context.Url.Where(predicate).ToListAsync();
        }

        public async Task<Url> Insert(Url url)
        {
            await _context.Url.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<Url> Update(Url url)
        {
            _context.Url.Update(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task Delete(Url url)
        {
            _context.Url.Remove(url);
            await _context.SaveChangesAsync();
        }
    }
}
