using Blog.Core.Entities;
using Blog.Data.SqlServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Mappers
{
    public static class CommentMapper
    {
        public static CommentModel ToTable(this Comment comment)
        {
            return new CommentModel
            {
                Id = comment.Id,
                BlogPostId = comment.BlogPostId,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }
    }
}
