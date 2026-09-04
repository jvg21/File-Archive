using FILEAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FILEAPI.Data.Maps
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).IsRequired();
            builder.HasIndex(b => b.Name).IsUnique();

            builder.Property(a => a.IsActive).HasDefaultValue(true);


        }
    }
}
