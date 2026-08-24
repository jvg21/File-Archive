using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FILEAPI.Data.Maps
{
    public class FileArchiveMap : IEntityTypeConfiguration<Models.FileArchive>
    {
        public void Configure(EntityTypeBuilder<Models.FileArchive> builder)
        {
            builder.ToTable("filearchive");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Path).IsRequired();
        }
    }
}
