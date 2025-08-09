using MediatR;

namespace TerraTrust.Business.Commands
{
    public record DeletePropertyCommand(int Id) : IRequest<bool>;
    
}
