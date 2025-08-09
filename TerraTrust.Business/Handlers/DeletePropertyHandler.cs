using MediatR;
using TerraTrust.Business.Commands;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Interfaces;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    internal class DeletePropertyHandler : IRequestHandler<DeletePropertyCommand, bool>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        private readonly IBaseRepository<Owner> _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePropertyHandler(IBaseRepository<Property> propertyRepository,
                                IBaseRepository<Owner> ownerRepository,
                                IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            bool deleletedProperty = await _propertyRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return deleletedProperty;
        }
    }
}
