using Blog.Core.Entities;
using Blog.Core.UseCases.GetAllPosts;

namespace Blog.Core.Repositories
{
    public interface IBlogPostQueryRepository
    {
        Task<IEnumerable<GetAllPostsPresenter>> GetAllPosts(CancellationToken cancellationToken);
        Task Create(BlogPost blogPost, CancellationToken cancellationToken);
        Task AddComment(Comment comment, CancellationToken cancellationToken);
    }
}
