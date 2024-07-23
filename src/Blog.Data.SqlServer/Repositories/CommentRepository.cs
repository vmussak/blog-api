using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Data.SqlServer.Context;
using Blog.Data.SqlServer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.SqlServer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext _context;

        public CommentRepository(BlogContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(Comment comment, CancellationToken cancellationToken)
        {
            var blogPostTable = comment.ToTable();

            await _context.AddAsync(blogPostTable, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
