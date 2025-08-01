using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTrust.Core.Interfaces.Repositories;

namespace TerraTrust.Core.Events
{
    public class DomainEvent 
    {
        public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
    }
}
