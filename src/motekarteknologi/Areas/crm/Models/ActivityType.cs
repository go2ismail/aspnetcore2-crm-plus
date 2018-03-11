using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Areas.crm.Models
{
    public class ActivityType : motekarteknologi.Models.BaseModel
    {
        public ActivityType()
        {
            this.NumberofDays = 0;
        }
        public int NumberofDays { get; set; }
        public ActivityType RecomendedNextActivity { get; set; }
    }
}
