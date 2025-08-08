using MediatR;
using TerraTrust.Business.DTOs;
using TerraTrust.Business.Queries;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Exceptions;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDto>
    {
        private readonly IBaseRepository<Property> _baseRepository;
        public GetPropertyByIdQueryHandler(IBaseRepository<Property> baseRepository)
        {
            _baseRepository = baseRepository;
        }   

        public async Task<PropertyDto> Handle(GetPropertyByIdQuery request,
                                              CancellationToken cancellationToken)
        {
            var property = await _baseRepository.GetByIdAsync(request.Id, cancellationToken);   
            
            if(property == null)
                throw new NotFoundException("Property not found.");

            return new PropertyDto
            {
                Id = property.Id,
                Name = property.Name,
                Type = property.Type,
                Coordinates = property.Coordinates,
                ZoningType = property.ZoningType,
                TerrainProfile = property.TerrainProfile,
                AreaInSquareMeters = property.AreaInSquareMeters,
                Value = property.Value
            };
        }
    }
}
