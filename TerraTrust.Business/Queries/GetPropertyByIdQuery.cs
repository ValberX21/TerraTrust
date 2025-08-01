using MediatR;
using TerraTrust.Business.DTOs;

namespace TerraTrust.Business.Queries
{
    public class GetPropertyByIdQuery : IRequest<PropertyDto>
    {
        public int Id { get; set; }
        public GetPropertyByIdQuery(int id)
        {
            Id = id;
        }
    }   
}
