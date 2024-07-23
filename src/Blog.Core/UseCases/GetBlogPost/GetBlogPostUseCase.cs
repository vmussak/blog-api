using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.UseCases.CreateBlogPost;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.GetBlogPost
{
    public class GetBlogPostUseCase : IUseCase<GetBlogPostRequest, GetBlogPostPresenter>
    {
        private readonly IBlogPostRepository _repository;
        private readonly ILogger<GetBlogPostUseCase> _logger;

        public GetBlogPostUseCase(IBlogPostRepository repository, ILogger<GetBlogPostUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<DefaultResult<GetBlogPostPresenter?>> Handle(GetBlogPostRequest request, CancellationToken cancellationToken)
        {
            //Maybe add a InMemory Cache here, with a 1 day TTL

            var blogPost = await _repository.GetById(request.Id, cancellationToken);

            return new DefaultResult<GetBlogPostPresenter?>(blogPost);
        }
    }
}
