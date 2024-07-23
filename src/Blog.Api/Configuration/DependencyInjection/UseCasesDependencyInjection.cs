using Blog.Core.Entities;
using Blog.Core.UseCases.CreateBlogPost;
using Blog.Core.UseCases;
using Blog.Core.UseCases.GetBlogPost;
using Blog.Core.UseCases.CreateReadBlogPost;
using Blog.Core.UseCases.CreateReadComment;
using Blog.Core.UseCases.GetAllPosts;
using Blog.Core.UseCases.CreateComment;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class UseCasesDependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<CreateBlogPostRequest, BlogPost>, CreateBlogPostUseCase>();
            services.AddScoped<IUseCase<GetBlogPostRequest, GetBlogPostPresenter>, GetBlogPostUseCase>();
            services.AddScoped<IUseCase<BlogPost, bool>, CreateReadBlogPostUseCase>();
            services.AddScoped<IUseCase<Comment, bool>, CreateReadCommentUseCase>();
            services.AddScoped<IUseCase<GetAllPostsRequest, IEnumerable<GetAllPostsPresenter>>, GetAllPostsUseCase>();
            services.AddScoped<IUseCase<CreateCommentRequest, Comment>, CreateCommentUseCase>();

            return services;
        }
    }
}
