using Blog.Core.Entities;
using Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.CreateReadComment
{
    public class CreateReadCommentUseCase : IUseCase<Comment, bool>
    {
        private readonly IBlogPostQueryRepository _blogPostQueryRepository;

        public CreateReadCommentUseCase(IBlogPostQueryRepository blogPostQueryRepository)
        {
            _blogPostQueryRepository = blogPostQueryRepository;
        }

        public async Task<DefaultResult<bool>> Handle(Comment request, CancellationToken cancellationToken)
        {
            await _blogPostQueryRepository.AddComment(request, cancellationToken);

            return new DefaultResult<bool>(true);
        }
    }
}
