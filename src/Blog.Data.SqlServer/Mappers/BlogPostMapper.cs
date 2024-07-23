using Blog.Core.Entities;
using Blog.Core.UseCases.GetBlogPost;
using Blog.Data.SqlServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog.Data.SqlServer.Mappers
{
    public static class BlogPostMapper
    {
        public static BlogPostModel ToTable(this BlogPost post)
        {
            return new BlogPostModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            };
        }

        public static GetBlogPostPresenter? ToGetByIdPresenter(this BlogPostModel model) 
        {
            if (model == null) return null;

            IEnumerable<GetBlogPostCommentPresenter> comments = null;

            if (model.Comments != null) 
            {
                comments = model.Comments.Select(c => new GetBlogPostCommentPresenter
                {
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                });
            }

            return new GetBlogPostPresenter
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = model.CreatedAt,
                Comments = comments
            };
        }
    }
}
