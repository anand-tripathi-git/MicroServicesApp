using RabbitMQ.Client;
using System;

namespace EventBusRabbitMQ
{
    public interface IRabbitMqConnection: IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
