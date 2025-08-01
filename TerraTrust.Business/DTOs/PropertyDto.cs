using TerraTrust.Core.Enums;

namespace TerraTrust.Business.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public PropertyType Type { get; set; }

        public string Coordinates { get; set; } = string.Empty; 

        public ZoningType ZoningType { get; set; }

        public string? TerrainProfile { get; set; }

        public double AreaInSquareMeters { get; set; }

        public decimal Value { get; set; }

        public PropertyStatus Status { get; set; } 

        public string FormattedValue => $"R$ {Value:N2}"; 
    }
}
