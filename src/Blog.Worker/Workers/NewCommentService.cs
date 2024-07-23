using System;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Core.UseCases;
using Blog.Core.Entities;
using System.Threading.Channels;
using System.Threading;

namespace Blog.Worker.Workers
{
    public class NewCommentService : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public NewCommentService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _connection = serviceProvider.GetRequiredService<IConnection>();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "comments", type: ExchangeType.Direct);

            _channel.QueueDeclare(queue: "comment_denormalize_queue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            _channel.QueueBind("comment_denormalize_queue", "comments", "created");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var comment = JsonSerializer.Deserialize<Comment>(message);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var useCase = scope.ServiceProvider.GetRequiredService<IUseCase<Comment, bool>>();

                    await useCase.Handle(comment, stoppingToken);
                }
            };

            _channel.BasicConsume(queue: "comment_denormalize_queue",
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
