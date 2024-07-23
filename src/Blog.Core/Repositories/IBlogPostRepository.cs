using Blog.Core.Entities;
using Blog.Core.UseCases.GetBlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IBlogPostRepository
    {
        Task CreateAsync(BlogPost blogPost, CancellationToken cancellationToken);
        Task<GetBlogPostPresenter?> GetById(Guid id, CancellationToken cancellationToken);
    }
}
