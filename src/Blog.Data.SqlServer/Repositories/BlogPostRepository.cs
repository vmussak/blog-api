using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.UseCases.GetBlogPost;
using Blog.Data.SqlServer.Context;
using Blog.Data.SqlServer.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogContext _context;

        public BlogPostRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(BlogPost blogPost, CancellationToken cancellationToken)
        {
            var blogPostTable = blogPost.ToTable();

            await _context.AddAsync(blogPostTable, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<GetBlogPostPresenter?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var blogPost = await _context.Posts
                .Include(x => x.Comments)
                .AsSplitQuery()
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == id);

            return blogPost?.ToGetByIdPresenter();
        }
    }
}
