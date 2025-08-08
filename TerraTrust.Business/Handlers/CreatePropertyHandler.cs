using MediatR;
using System;
using TerraTrust.Business.Commands;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Exceptions;
using TerraTrust.Core.Interfaces;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, int>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        private readonly IBaseRepository<Owner> _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePropertyHandler(IBaseRepository<Property> propertyRepository,
                                     IBaseRepository<Owner> ownerRepository,
                                     IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(request.OwnerId);

            if (owner == null)
                throw new NotFoundException("Owner not found.");

            var property = new Property
            (
                request.Name,
                (PropertyType)request.Type,
                "0,0",
                ZoningType.ProtectedArea,
                request.OwnerId
            );

            await _propertyRepository.AddAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return property.Id;
        }
    }
}
