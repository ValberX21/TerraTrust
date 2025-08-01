using MediatR;
using TerraTrust.Business.Commands;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class CreateOwnerHandler : IRequestHandler<CreateOwnerCommand, int>
    {
        private readonly IBaseRepository<Owner> _ownerRepository;

        public CreateOwnerHandler(IBaseRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var property = new Owner
            (
                request.Type,
                request.FullName,
                request.TradeName,
                request.DocumentNumber,
                request.Email,
                request.PhoneNumber,
                request.City,
                request.State,  
                request.Country
            );

            await _ownerRepository.AddAsync(property);
            return property.Id;
        }
    }
}
