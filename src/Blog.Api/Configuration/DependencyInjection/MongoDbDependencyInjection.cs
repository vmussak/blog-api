using Blog.Data.MongoDb.Collections;
using MongoDB.Driver;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class MongoDbDependencyInjection
    {
        public static IServiceCollection AddBlogMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoClient>(x => new MongoClient(configuration.GetConnectionString("PostsMongoDb")));
            services.AddSingleton<IMongoDatabase>(
                provider => provider.GetRequiredService<MongoClient>().GetDatabase("blog"));
            services.AddScoped<IMongoCollection<PostsCollection>>(
                provider => provider.GetRequiredService<IMongoDatabase>().GetCollection<PostsCollection>("posts"));

            return services;
        }
    }
}
