using LifeSafeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeSafeAPI.Data.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AuthorGetDTO> Author { get; set; }
    }
}
