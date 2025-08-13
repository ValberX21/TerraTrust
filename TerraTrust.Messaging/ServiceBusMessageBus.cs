using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using System.Text.Json;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Interfaces;

namespace TerraTrust.Messaging
{
    public class ServiceBusMessageBus : IMessageBus, IAsyncDisposable
    {
        private readonly ServiceBusSender _sender;  
        private readonly ServiceBusClient _client;

        public ServiceBusMessageBus(IOptions<ServiceBusOptions> opts)
        {
            _client = new ServiceBusClient(opts.Value.Connection);
            _sender = _client.CreateSender(opts.Value.QueueName);

        }

        public async Task PublishAsync(string subject, object payload, string? sessionId = null, CancellationToken ct = default)
        {
            var body =  JsonSerializer.Serialize(payload);
            
            var mesn =  new ServiceBusMessage(body)
            {
               ContentType = "application/json",
                Subject = subject,
                MessageId = Guid.NewGuid().ToString(),  
            };

            if(!string.IsNullOrEmpty(sessionId))            
                mesn.SessionId = sessionId;
               
            await _sender.SendMessageAsync(mesn, ct);   

        }

        public async ValueTask DisposeAsync()
        {
            await _sender.DisposeAsync();
            await _client.DisposeAsync();
        }
    }
}
