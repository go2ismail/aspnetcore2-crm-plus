using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.Models
{
    public class SalesChannel : motekarteknologi.Models.BaseModel
    {
        public SalesChannel()
        {
            this.TeamMembers = new List<motekarteknologi.Models.ApplicationUser>();
        }

        public motekarteknologi.Models.ApplicationUser ChannelLeader { get; set; }

        public ICollection<motekarteknologi.Models.ApplicationUser> TeamMembers { get; set; }
    }
}
