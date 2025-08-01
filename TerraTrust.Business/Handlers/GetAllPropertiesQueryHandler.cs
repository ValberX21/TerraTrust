using MediatR;
using System.Xml.Linq;
using TerraTrust.Business.DTOs;
using TerraTrust.Business.Queries;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, IEnumerable<PropertyDto>>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        public GetAllPropertiesQueryHandler(IBaseRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<PropertyDto>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsync();

            return properties.Select(p => new PropertyDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                Coordinates = p.Coordinates,
                ZoningType = p.ZoningType,
                TerrainProfile = p.TerrainProfile,
                AreaInSquareMeters = p.AreaInSquareMeters,
                Value = p.Value
            });
        }
    }
}
