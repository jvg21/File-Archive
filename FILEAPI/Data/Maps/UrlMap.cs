using FILEAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FILEAPI.Data.Maps
{
    public class UrlMap: IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.ToTable("url");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Content);
            builder.HasIndex(u => u.Content);

            builder.Property(a => a.IsActive).HasDefaultValue(true);


            // 1 AUTHOR -> N URLS

            builder.HasOne(u => u.Author).WithMany(a => a.URLS).HasForeignKey(u => u.Author_Id).OnDelete(DeleteBehavior.Cascade).IsRequired(false);


            //1 BOOK -> N URLS
            builder.HasOne(u=> u.Book).WithMany(b=>b.URLS).HasForeignKey(u=>u.Book_Id).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        }
    }
}
