using MediatR;
using TerraTrust.Business.Commands;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Exceptions;
using TerraTrust.Core.Interfaces;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class UpdatePropertyHandler : IRequestHandler<UpdatePropertyCommand, bool>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        private readonly IBaseRepository<Owner> _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePropertyHandler(IBaseRepository<Property> propertyRepository,
                                    IBaseRepository<Owner> ownerRepository,
                                    IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(request.OwnerId);

            if (owner == null)
                throw new NotFoundException("Owner not found.");

            var proertyExist = await _propertyRepository.GetByIdAsync(request.Id);
            if (proertyExist == null)
                throw new NotFoundException("Property not found.");



            proertyExist.UpdateProperty
            (   
                request.Name,
                (PropertyType)request.Type,
                "0,0",
                ZoningType.ProtectedArea,
                request.OwnerId
            );

            bool updateresult = await _propertyRepository.UpdateAsync(proertyExist);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return updateresult;
        }
    }
}
