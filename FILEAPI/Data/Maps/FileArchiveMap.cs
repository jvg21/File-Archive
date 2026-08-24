using FILEAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FILEAPI.Data.Maps
{
    public class FileArchiveMap : IEntityTypeConfiguration<FileArchive>
    {
        public void Configure(EntityTypeBuilder<FileArchive> builder)
        {
            builder.ToTable("filearchive");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Path).IsRequired();


            builder.HasOne(f => f.Book).WithMany(b => b.Files).HasForeignKey(f => f.Book_Id).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(f => f.Author).WithMany(a => a.Files).HasForeignKey(f => f.Author_Id).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }

    }
}
