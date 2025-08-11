using MediatR;
using Polly.Caching;
using System.Xml.Linq;
using TerraTrust.Business.DTOs;
using TerraTrust.Business.Queries;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Business.Handlers
{
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, PagedResult<PropertyDto>>
    {
        private readonly IBaseRepository<Property> _propertyRepository;
        public GetAllPropertiesQueryHandler(IBaseRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PagedResult<PropertyDto>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            // var skip = (request.Page - 1) * request.PageSize;

            var totalRecords = await _propertyRepository.CountAsync();

            var properties = await _propertyRepository.GetPagedAsync(request.Page, request.PageSize);

            var items = properties.Select(p => new PropertyDto
            {
                Id = p.Id,
                Name = p.Name,
                Coordinates = p.Coordinates,
                TerrainProfile = p.TerrainProfile,
                AreaInSquareMeters = p.AreaInSquareMeters,
                Value = p.Value,
            }).ToList();

            return new PagedResult<PropertyDto>(items, totalRecords, request.Page, request.PageSize);

        }     
    }
}
