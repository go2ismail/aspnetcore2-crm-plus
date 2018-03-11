using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace motekarteknologi.Models
{
    public class BaseAddressModel : BaseModel
    {
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(100)]
        public string Street2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string State { get; set; }
        [StringLength(20)]
        public string ZIP { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
    }
}
