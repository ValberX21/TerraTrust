using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Events;

namespace TerraTrust.Core.Entities
{
    public class Property : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Coordinates { get; set; }  // e.g., "latitude,longitude"

        [Required]
        public ZoningType ZoningType { get; set; }

        [MaxLength(50)]
        public string TerrainProfile { get; set; }  // e.g., "Flat", "Hilly"

        [Column(TypeName = "float")]
        public double AreaInSquareMeters { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        public PropertyStatus Status { get; set; }

        //////////////////////////////////////////////////////////////////

        public Property(string name, PropertyType type, string coordinates, ZoningType zoningType)
        {
            Name = name;
            Type = type;
            Coordinates = coordinates;
            ZoningType = zoningType;

            AddDomainEvent(new PropertyCreatedEvent(name, type, coordinates, zoningType));
        }

    }
}
