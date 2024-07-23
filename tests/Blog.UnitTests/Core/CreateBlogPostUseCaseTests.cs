using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.UseCases.CreateBlogPost;
using Blog.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UnitTests.Core
{
    public class CreateBlogPostUseCaseTests
    {
        private readonly BlogPostValidator _validator;
        private readonly Mock<IBlogPostRepository> _repository;
        private readonly Mock<IMessagePublisherRepository> _messagePublisher;
        private readonly Mock<ILogger<CreateBlogPostUseCase>> _logger;

        public CreateBlogPostUseCaseTests()
        {
            _validator = new();
            _repository = new();
            _messagePublisher = new();
            _logger = new();
        }

        [Fact]  
        public async Task CreateBlogPostUseCase_When_RequestInvalid_Should_Return_Error()
        {
            var request = new CreateBlogPostRequest
            {
                Title = "Title",
                Content = string.Empty
            };

            var useCase = new CreateBlogPostUseCase(
                _validator,
                _repository.Object,
                _messagePublisher.Object,
                _logger.Object
            );

            var response = await useCase.Handle(request, CancellationToken.None);

            Assert.False(response.Success);
        }

        [Fact]
        public async Task CreateBlogPostUseCase_When_RequestValid_Should_Return_Success()
        {
            var request = new CreateBlogPostRequest
            {
                Title = "Title",
                Content = "Content"
            };

            var useCase = new CreateBlogPostUseCase(
                _validator,
                _repository.Object,
                _messagePublisher.Object,
                _logger.Object
            );

            var response = await useCase.Handle(request, CancellationToken.None);

            Assert.True(response.Success);
            _repository.Verify(x => x.CreateAsync(It.IsAny<BlogPost>(), CancellationToken.None), Times.Once());
            _messagePublisher.Verify(x => x.Publish(It.IsAny<BlogPost>(), "posts", "created"), Times.Once());
        }

    }
}
