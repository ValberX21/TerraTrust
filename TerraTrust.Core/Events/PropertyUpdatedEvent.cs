namespace TerraTrust.Core.Events
{
    public class PropertyUpdatedEvent: DomainEvent
    {
        public int PropertyId { get; }

        public PropertyUpdatedEvent(int propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
