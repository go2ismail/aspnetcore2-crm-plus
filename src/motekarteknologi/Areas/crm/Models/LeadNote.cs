using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.Models
{
    public class LeadNote : motekarteknologi.Models.BaseModel
    {
        public Lead Lead { get; set; }
    }
}
