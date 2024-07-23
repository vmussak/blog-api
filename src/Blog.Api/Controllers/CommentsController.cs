using Blog.Core.Entities;
using Blog.Core.UseCases;
using Blog.Core.UseCases.CreateComment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUseCase<CreateCommentRequest, Comment> _useCase;

        public CommentsController(IUseCase<CreateCommentRequest, Comment> useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("posts/{postId}/comments")]
        public async Task<IActionResult> Create(Guid postId, CreateCommentRequest request, CancellationToken cancellationToken)
        {
            request.PostId = postId;
            var response = await _useCase.Handle(request, cancellationToken);

            if (!response.Success)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Data);
        }
    }
}
