using FILEAPI.Data.Models;
using FILEAPI.Data.Maps;
using Microsoft.EntityFrameworkCore;


namespace FILEAPI.Data.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorMap());
        }
    }
}
