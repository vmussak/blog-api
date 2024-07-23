using Blog.Core.UseCases;
using Blog.Core.UseCases.CreateBlogPost;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Core.Entities;
using Azure.Core;
using System.Threading;
using Blog.Core.UseCases.GetBlogPost;
using Blog.Core.UseCases.GetAllPosts;

namespace Blog.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUseCase<CreateBlogPostRequest, BlogPost> _createBlogPostUseCase;
        private readonly IUseCase<GetBlogPostRequest, GetBlogPostPresenter> _getBlogPostUseCase;
        private readonly IUseCase<GetAllPostsRequest, IEnumerable<GetAllPostsPresenter>> _getAllPostsUseCase;

        public PostsController(IUseCase<CreateBlogPostRequest, BlogPost> createBlogPostUseCase, IUseCase<GetBlogPostRequest, GetBlogPostPresenter> getBlogPostUseCase, IUseCase<GetAllPostsRequest, IEnumerable<GetAllPostsPresenter>> getAllPostsUseCase)
        {
            _createBlogPostUseCase = createBlogPostUseCase;
            _getBlogPostUseCase = getBlogPostUseCase;
            _getAllPostsUseCase = getAllPostsUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            //v1 was a simple COUNT(*) at comments table
            var request = new GetAllPostsRequest();
            var response = await _getAllPostsUseCase.Handle(request, cancellationToken);

            return Ok(response.Data);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetBlogPostRequest { Id = id };
            var response = await _getBlogPostUseCase.Handle(request, cancellationToken);

            if (response.Success && response.Data != null)
            {
                return Ok(response.Data);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogPostRequest request, CancellationToken cancellationToken)
        {
            var response = await _createBlogPostUseCase.Handle(request, cancellationToken);

            if (response.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);
            }

            return BadRequest(response.Messages);
        }
    }
}
