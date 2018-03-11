using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace motekarteknologi.Areas.crm.Models
{
    public class Customer : motekarteknologi.Models.BaseAddressModel
    {
        public Customer()
        {
            this.LineAdditionalContact = new List<CustomerAdditionalContact>();
            this.LineNote = new List<CustomerNote>();
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
        public CustomerType CustomerType { get; set; }

        public ICollection<CustomerAdditionalContact> LineAdditionalContact { get; set; }
        public ICollection<CustomerNote> LineNote { get; set; }
        public ICollection<CustomerActivity> LineActivity { get; set; }
    }
}
