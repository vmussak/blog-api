using Blog.Data.SqlServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPostModel>
    {
        public void Configure(EntityTypeBuilder<BlogPostModel> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(100)").HasColumnName("Username");
            builder.Property(x => x.Content).IsRequired().HasColumnType("varchar(max)").HasColumnName("Content");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime").HasColumnName("CreatedAt");

            builder.HasMany(x => x.Comments)
               .WithOne(x => x.BlogPost)
               .HasForeignKey(x => x.BlogPostId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasAnnotation("SqlAfterTableCreated", "EXEC sp_tableoption 'Posts', 'large value types out of row', 1");
        }
    }
}
