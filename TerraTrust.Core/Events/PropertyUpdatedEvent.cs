namespace TerraTrust.Core.Events
{
    public class PropertyUpdatedEvent: DomainEvent
    {
        public Guid PropertyId { get; }

        public PropertyUpdatedEvent(Guid propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
