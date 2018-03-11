using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.Models
{
    public class CustomerAdditionalContact : motekarteknologi.Models.BaseModel
    {
        public Customer Customer { get; set; }
    }
}
