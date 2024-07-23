using Blog.Data.SqlServer.Context;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Blog.Api.Configuration.DependencyInjection
{
    public static class RabbitMqDependencyInjection
    {
        public static IServiceCollection AddBlogRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqConfiguration = configuration.GetSection("RabbitMq");

            services.AddSingleton<IConnection>(sp =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = rabbitMqConfiguration["HostName"],
                    UserName = rabbitMqConfiguration["UserName"],
                    Password = rabbitMqConfiguration["Password"]
                };

                return factory.CreateConnection();
            });

            return services;
        }
    }
}

/*builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMq"));

// Registrar a conexão RabbitMQ como singleton
*/