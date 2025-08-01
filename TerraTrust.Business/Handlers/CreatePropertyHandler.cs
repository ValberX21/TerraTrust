using MediatR;
using System;
using TerraTrust.Business.Commands;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, int>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        private readonly IBaseRepository<Owner> _ownerRepository;
        public CreatePropertyHandler(IBaseRepository<Property> propertyRepository, IBaseRepository<Owner> ownerRepository)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;

        }

        public async Task<int> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(request.OwnerId);
            if (owner == null)
                throw new Exception("Owner not found.");

            var property = new Property
            (
                request.Name,
                (PropertyType)request.Type,
                "0,0",
                ZoningType.ProtectedArea,
                request.OwnerId
            );

            await _propertyRepository.AddAsync(property);
            return property.Id;
        }
    }
}
