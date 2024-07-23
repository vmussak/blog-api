using Blog.Core.Entities;

namespace Blog.Core.Repositories
{
    public interface ICommentRepository
    {
        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
    }
}
