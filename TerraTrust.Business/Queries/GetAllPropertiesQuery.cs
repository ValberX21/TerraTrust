using MediatR;
using TerraTrust.Business.DTOs;

namespace TerraTrust.Business.Queries
{
    public class GetAllPropertiesQuery : IRequest<IEnumerable<PropertyDto>>
    {
    }
}
