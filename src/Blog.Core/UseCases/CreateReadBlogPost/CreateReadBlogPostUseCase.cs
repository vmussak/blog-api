using Blog.Core.Entities;
using Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.CreateReadBlogPost
{
    public class CreateReadBlogPostUseCase : IUseCase<BlogPost, bool>
    {
        private readonly IBlogPostQueryRepository _blogPostQueryRepository;

        public CreateReadBlogPostUseCase(IBlogPostQueryRepository blogPostQueryRepository)
        {
            _blogPostQueryRepository = blogPostQueryRepository;
        }

        public async Task<DefaultResult<bool>> Handle(BlogPost request, CancellationToken cancellationToken)
        {
            await _blogPostQueryRepository.Create(request, cancellationToken);

            return new DefaultResult<bool>(true);
        }
    }
}
