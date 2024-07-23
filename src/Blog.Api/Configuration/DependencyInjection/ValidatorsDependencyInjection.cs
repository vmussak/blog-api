using Blog.Core.Entities;
using Blog.Core.UseCases.CreateBlogPost;
using Blog.Core.UseCases;
using FluentValidation;
using Blog.Core.Validators;
using Blog.Core.UseCases.CreateComment;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class ValidatorsDependencyInjection
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateBlogPostRequest>, BlogPostValidator>();
            services.AddScoped<IValidator<CreateCommentRequest>, CommentValidator>();

            return services;
        }
    }
}
