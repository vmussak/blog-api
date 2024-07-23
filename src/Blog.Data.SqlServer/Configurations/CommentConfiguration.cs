using System;
using Blog.Data.SqlServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.BlogPostId).HasColumnName("PostId");
            builder.Property(x => x.Content).IsRequired().HasColumnType("varchar(400)").HasColumnName("Content");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime").HasColumnName("CreatedAt");

            builder.HasOne(x => x.BlogPost)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.BlogPostId);

            builder.HasIndex(a => a.BlogPostId)
                .IncludeProperties(x => new { x.Content, x.CreatedAt })
                .HasDatabaseName("IDX_Comments_BlogPostId");
        }
    }
}
