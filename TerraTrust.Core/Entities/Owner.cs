using TerraTrust.Core.Enums;

namespace TerraTrust.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        public OwnerType Type { get; set; }

        public string FullName { get; set; }          // Nome completo ou Razão Social
        public string? TradeName { get; set; }        // Nome fantasia (se Company)
        public string DocumentNumber { get; set; }    // CPF/CNPJ

        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set; }

        // Simple address fields (swap to a Value Object if you prefer)
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; } = "BR";

        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
