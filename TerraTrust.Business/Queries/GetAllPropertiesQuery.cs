using MediatR;
using TerraTrust.Business.DTOs;

namespace TerraTrust.Business.Queries
{
    public record GetAllPropertiesQuery(int Page = 1, int PageSize = 5) : IRequest<PagedResult<PropertyDto>>
    {}
}
