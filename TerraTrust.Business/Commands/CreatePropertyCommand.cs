using MediatR;
using TerraTrust.Core.Enums;

namespace TerraTrust.Business.Commands
{
    public class CreatePropertyCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public PropertyType Type { get; set; } 
        public int OwnerId { get; set; }
    }
}
