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

namespace Blog.Core.UseCases.CreateComment
{
    public class CreateCommentUseCase : IUseCase<CreateCommentRequest, Comment>
    {
        private readonly IValidator<CreateCommentRequest> _validator;
        private readonly ICommentRepository _repository;
        private readonly IMessagePublisherRepository _messagePublisher;
        private readonly ILogger<CreateCommentUseCase> _logger;

        public CreateCommentUseCase(IValidator<CreateCommentRequest> validator, ICommentRepository repository, IMessagePublisherRepository messagePublisher, ILogger<CreateCommentUseCase> logger)
        {
            _validator = validator;
            _repository = repository;
            _messagePublisher = messagePublisher;
            _logger = logger;
        }

        public async Task<DefaultResult<Comment>> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var postValidation = await _validator.ValidateAsync(request, cancellationToken);

            if (!postValidation.IsValid)
            {
                return new DefaultResult<Comment>(postValidation.Errors);
            }

            var comment = new Comment(request.PostId, request.Content);

            await _repository.CreateAsync(comment, cancellationToken);
            _logger.LogInformation("Comment {Id} was created at Post {PostId}", comment.Id, comment.BlogPostId);

            _messagePublisher.Publish(comment, "comments", "created");
            _logger.LogInformation("Comment {Id} was published", comment.Id);

            return new DefaultResult<Comment>(comment);
        }
    }
}
