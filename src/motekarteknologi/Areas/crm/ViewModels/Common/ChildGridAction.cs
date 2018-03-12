using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.ViewModels.Common
{
    public class ChildGridAction
    {
        public Guid ID { get; set; }
        public Guid MasterID { get; set; }
        public string DestinationControllerName { get; set; }
    }
}
