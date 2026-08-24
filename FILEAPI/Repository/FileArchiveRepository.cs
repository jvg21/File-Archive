using FILEAPI.Data.Database;
using FILEAPI.Data.Models;
using FILEAPI.Migrations;
using FILEAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FILEAPI.Repository
{
    public class FileArchiveRepository : IFileArchiveRepository
    {
        private readonly AppDbContext _context;

        public FileArchiveRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<FileArchive>> GetAll()
        {
            return await _context.FileArchive.AsNoTracking().ToListAsync();
        }

        public async Task<FileArchive?> GetById(int id)
        {
            return await _context.FileArchive.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<FileArchive>> Get(Expression<Func<FileArchive, bool>> predicate)
        {
            return await _context.FileArchive.Where(predicate).ToListAsync();
        }

        public async Task<FileArchive> Insert(FileArchive fileArchive)
        {
            await _context.FileArchive.AddAsync(fileArchive);
            await _context.SaveChangesAsync();
            return fileArchive;
        }

        public async Task<FileArchive> Update(FileArchive fileArchive)
        {
            _context.FileArchive.Update(fileArchive);
            await _context.SaveChangesAsync();
            return fileArchive;
        }

        public async Task Delete(FileArchive fileArchive)
        {
            _context.FileArchive.Remove(fileArchive);
            await _context.SaveChangesAsync();
        }
    }
}
