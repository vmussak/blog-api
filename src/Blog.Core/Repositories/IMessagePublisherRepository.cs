using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IMessagePublisherRepository
    {
        void Publish<T>(T message, string exchangeName, string routingKey);
    }
}
