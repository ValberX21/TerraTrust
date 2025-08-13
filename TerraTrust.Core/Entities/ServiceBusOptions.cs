using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTrust.Core.Entities
{
    public class ServiceBusOptions
    {
        public string Connection { get; set; } = string.Empty;
        public string QueueName { get; set; } = string.Empty;
    }
}
