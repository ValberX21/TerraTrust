using MediatR;
using TerraTrust.Core.Entities;
using TerraTrust.Core.Enums;

namespace TerraTrust.Business.Commands
{
    public class UpdatePropertyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PropertyType Type { get; set; }
        public int OwnerId { get; set; }
    }
}
