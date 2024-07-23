using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.UseCases.CreateBlogPost;

namespace Blog.Core.Validators
{
    public class BlogPostValidator : AbstractValidator<CreateBlogPostRequest>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
