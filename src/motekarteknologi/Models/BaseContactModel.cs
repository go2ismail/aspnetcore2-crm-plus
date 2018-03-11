using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace motekarteknologi.Models
{
    public class BaseContactModel : BaseModel
    {
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
    }
}
