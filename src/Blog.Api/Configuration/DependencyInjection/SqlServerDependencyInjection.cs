using Blog.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class SqlServerDependencyInjection
    {
        public static IServiceCollection AddBlogSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BlogConnectionString");

            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Blog.Data.SqlServer"))
            );

            return services;
        }

        public static IServiceProvider ConfigureSqlServer(this IServiceProvider services)
        {
            var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BlogContext>();

            var pendingMigrations = db.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                db.Database.Migrate();
            }

            return services;
        }
    }
}
