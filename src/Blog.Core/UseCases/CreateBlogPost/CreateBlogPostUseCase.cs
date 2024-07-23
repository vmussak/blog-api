using Blog.Core.Entities;
using Blog.Core.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases.CreateBlogPost
{
    public class CreateBlogPostUseCase : IUseCase<CreateBlogPostRequest, BlogPost>
    {
        private readonly IValidator<CreateBlogPostRequest> _validator;
        private readonly IBlogPostRepository _repository;
        private readonly IMessagePublisherRepository _messagePublisher;
        private readonly ILogger<CreateBlogPostUseCase> _logger;

        public CreateBlogPostUseCase(IValidator<CreateBlogPostRequest> validator, IBlogPostRepository repository, IMessagePublisherRepository messagePublisher, ILogger<CreateBlogPostUseCase> logger)
        {
            _validator = validator;
            _repository = repository;
            _messagePublisher = messagePublisher;
            _logger = logger;
        }

        public async Task<DefaultResult<BlogPost>> Handle(CreateBlogPostRequest request, CancellationToken cancellationToken)
        {
            var postValidation = await _validator.ValidateAsync(request, cancellationToken);

            if (!postValidation.IsValid)
            {
                return new DefaultResult<BlogPost>(postValidation.Errors);
            }

            var blogPost = new BlogPost(request.Title, request.Content);

            await _repository.CreateAsync(blogPost, cancellationToken);
            _logger.LogInformation("Post {Id} was created", blogPost.Id);

            _messagePublisher.Publish(blogPost, "posts", "created");
            _logger.LogInformation("Post {Id} was published", blogPost.Id);

            return new DefaultResult<BlogPost>(blogPost);
        }
    }
}
