using Blog.Core.UseCases.CreateBlogPost;
using Blog.Core.UseCases.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Validators
{
    public class CommentValidator : AbstractValidator<CreateCommentRequest>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty");
            RuleFor(x => x.PostId).NotEqual(Guid.Empty).WithMessage("PostId cannot be empty");
        }
    }
}
