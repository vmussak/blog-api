using Blog.Core.Entities;
using Blog.Core.UseCases.CreateBlogPost;
using Blog.Core.UseCases;
using Blog.Core.Repositories;
using Blog.Data.SqlServer.Repositories;
using Blog.Data.RabbitMq;
using Blog.Data.MongoDb.Repositories;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class RepositoriesDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IMessagePublisherRepository, RabbitMqMessagePublisher>();
            services.AddScoped<IBlogPostQueryRepository, PostsQueryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
