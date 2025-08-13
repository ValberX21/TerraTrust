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
        private readonly IMessageBus _mesBus;

        public CreatePropertyHandler(IBaseRepository<Property> propertyRepository,
                                     IBaseRepository<Owner> ownerRepository,
                                     IUnitOfWork unitOfWork,
                                     IMessageBus mesBus)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
            _mesBus = mesBus;
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
            await _mesBus.PublishAsync("property.created", property, property.Id.ToString(), cancellationToken);

            return property.Id;
        }
    }
}
