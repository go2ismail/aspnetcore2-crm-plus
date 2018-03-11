using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace motekarteknologi.Areas.crm.Models
{
    public class Lead : motekarteknologi.Models.BaseAddressModel
    {
        public Lead()
        {
            this.Priority = 0;
            this.LineAdditionalContact = new List<LeadAdditionalContact>();
            this.LineNote = new List<LeadNote>();
            this.IsQualified = false;
        }
        [StringLength(200)]
        public string ContactName { get; set; }
        [StringLength(100)]
        public string JobPosition { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }

        public motekarteknologi.Models.ApplicationUser SalesPerson { get; set; }
        public SalesChannel SalesChannel { get; set; }
        public LeadType LeadType { get; set; }
        public int Priority { get; set; }
        public bool IsQualified { get; set; }

        public ICollection<LeadAdditionalContact> LineAdditionalContact { get; set; }
        public ICollection<LeadNote> LineNote { get; set; }
        public ICollection<LeadActivity> LineActivity { get; set; }
    }
}
