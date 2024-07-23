using Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.GetAllPosts
{
    public class GetAllPostsUseCase : IUseCase<GetAllPostsRequest, IEnumerable<GetAllPostsPresenter>>
    {
        private readonly IBlogPostQueryRepository _repository;

        public GetAllPostsUseCase(IBlogPostQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DefaultResult<IEnumerable<GetAllPostsPresenter>>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetAllPosts(cancellationToken);

            return new DefaultResult<IEnumerable<GetAllPostsPresenter>>(posts);
        }
    }
}
