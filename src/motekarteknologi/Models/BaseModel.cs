using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace motekarteknologi.Models
{
    //about datetime, offset and timezone: https://docs.microsoft.com/en-us/dotnet/standard/datetime/index
    public class BaseModel
    {
        public BaseModel()
        {
            this.CreatedDateUtc = DateTime.UtcNow;
            this.IsActive = true;

        }
        public Guid ID { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Max 100, Min 3 characters.")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Max 200, Min 3 characters.")]
        public string Description { get; set; }
    }
}
