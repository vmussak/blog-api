using Blog.Core.Repositories;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Data.RabbitMq
{
    public class RabbitMqMessagePublisher : IMessagePublisherRepository
    {
        private readonly IConnection _connection;

        public RabbitMqMessagePublisher(IConnection connection)
        {
            _connection = connection;
        }

        public void Publish<T>(T message, string exchangeName, string routingKey)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
