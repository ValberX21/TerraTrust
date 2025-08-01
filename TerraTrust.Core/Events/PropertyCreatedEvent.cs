using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;

namespace TerraTrust.Core.Events
{
    public class PropertyCreatedEvent : DomainEvent
    {
        public string Name { get; }
        public PropertyType Type { get; }
        public string Coordinates { get; }
        public ZoningType ZoningType { get; }
        public int OwnerId { get; }

        public PropertyCreatedEvent(string name, PropertyType type, string coordinates, ZoningType zoningType, int ownerId)
        {
            Name = name;
            Type = type;
            Coordinates = coordinates;
            ZoningType = zoningType;
            OwnerId = ownerId;
        }
    }
}
