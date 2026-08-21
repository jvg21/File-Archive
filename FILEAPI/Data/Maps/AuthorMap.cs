using FILEAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FILEAPI.Data.Maps
{
    public class AuthorMap :IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder) {

            builder.ToTable("author");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(60).IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();


            // N Author <--> N Book

            builder.HasMany(a => a.Books).WithMany(b => b.Authors).UsingEntity(j => j.ToTable("Book_Author"));

        }
    }
}
