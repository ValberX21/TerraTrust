namespace TerraTrust.Messaging.Contratcs
{
    public record CreatePropertyMessage
    (
        int Id,
        string Name,
        int Type,
        string OwnerName,
        string? CorrelationId
    );    
}
