using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class LineItem : BaseEntity<Guid>
    {
      
        public int Qty { get; set; }
        [JsonIgnore]
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
