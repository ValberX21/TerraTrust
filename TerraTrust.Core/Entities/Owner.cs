using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Events;

namespace TerraTrust.Core.Entities
{
    public class Owner : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public OwnerType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string? TradeName { get; set; }

        [Required]
        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = "";

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(20)]
        public string? SecondaryPhoneNumber { get; set; }

        [MaxLength(100)]
        public string? AddressLine1 { get; set; }

        [MaxLength(100)]
        public string? AddressLine2 { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(2)]
        public string? State { get; set; }

        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [MaxLength(2)]
        public string? Country { get; set; } = "BR";

        public bool IsActive { get; set; } = true;
        

        public Owner(                     
                     OwnerType type,
                     string fullName,
                     string? tradeName,
                     string documentNumber,
                     string email,
                     string? phoneNumber,
                     string? city,
                     string? state,
                     string? country)
                {                
                Type = type;
                FullName = fullName;
                TradeName = tradeName;
                DocumentNumber = documentNumber;
                Email = email;
                PhoneNumber = phoneNumber;
                City = city;
                State = state;
                Country = country;

                AddDomainEvent(new OwnerCreatedEvent(
                    type,
                    fullName,
                    tradeName,
                    documentNumber,
                    email,
                    phoneNumber,
                    city,
                    state,
                    country));
            }

    }
}
