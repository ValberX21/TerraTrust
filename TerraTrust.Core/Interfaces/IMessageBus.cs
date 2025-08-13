namespace TerraTrust.Core.Interfaces
{
    public interface IMessageBus
    {
        Task PublishAsync(string subject, object payload, string? sessionId = null, CancellationToken ct = default);
    }
}
