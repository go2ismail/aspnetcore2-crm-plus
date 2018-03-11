using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.Models
{
    public class LeadAdditionalContact : motekarteknologi.Models.BaseContactModel
    {
        public Lead Lead { get; set; }
    }
}
