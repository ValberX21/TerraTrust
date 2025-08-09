using TerraTrust.Core.Enums;

namespace TerraTrust.Core.Events
{
    public class PropertyUpdatedEvent: DomainEvent
    {
        public int PropertyId { get; }
        public string Name { get; }
        public PropertyType Type { get; }
        public string Coordinates { get; }
        public ZoningType ZoningType { get; }
        public int OwnerId { get; }

        public PropertyUpdatedEvent(

            int propertyId,
            string name,
            PropertyType type,
            string coordinates,
            ZoningType zoningType,
            int ownerId)
        {
            PropertyId = propertyId;
            Name = name;
            Type = type;
            Coordinates = coordinates;
            ZoningType = zoningType;
            OwnerId = ownerId;
        }
    }
}
