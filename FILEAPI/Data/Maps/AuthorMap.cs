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

        }
    }
}
