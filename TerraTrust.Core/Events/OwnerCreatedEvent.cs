using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTrust.Core.Enums;

namespace TerraTrust.Core.Events
{
    public class OwnerCreatedEvent : DomainEvent
    {
        public int OwnerId { get; }
        public OwnerType Type { get; }
        public string FullName { get; }
        public string? TradeName { get; }
        public string DocumentNumber { get; }
        public string Email { get; }
        public string? PhoneNumber { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }

        public OwnerCreatedEvent(
            int ownerId,
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
            OwnerId = ownerId;
            Type = type;
            FullName = fullName;
            TradeName = tradeName;
            DocumentNumber = documentNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            City = city;
            State = state;
            Country = country;
        }

        public OwnerCreatedEvent(OwnerType type, string fullName, string? tradeName, string documentNumber, string email, string? phoneNumber, string? city, string? state, string? country)
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
        }
    }
}
