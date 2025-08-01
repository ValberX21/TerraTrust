using MediatR;
using System.ComponentModel.DataAnnotations;
using TerraTrust.Core.Enums;

namespace TerraTrust.Business.Commands
{
    public class CreateOwnerCommand : IRequest<int>
    {
        [Required]
        public OwnerType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? TradeName { get; set; }

        [Required]
        [MaxLength(20)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

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
    }
}
