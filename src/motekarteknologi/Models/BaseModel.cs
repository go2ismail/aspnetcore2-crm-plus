using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Models
{
    //about datetime, offset and timezone: https://docs.microsoft.com/en-us/dotnet/standard/datetime/index
    public class BaseModel
    {
        public BaseModel()
        {
            this.CreatedDateUtc = DateTime.UtcNow;
        }
        public Guid ID { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
