using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace motekarteknologi.Areas.crm.Models
{
    public class Opportunity : motekarteknologi.Models.BaseModel
    {
        public Opportunity()
        {
            this.Priority = 0;
            this.ExpectedRevenue = 0;
            this.IsWon = false;
            this.IsLost = false;
            this.ExpectedClosing = DateTime.UtcNow;
        }
        public Lead Lead { get; set; }
        public Customer Customer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal ExpectedRevenue { get; set; }
        public int Priority { get; set; }
        public PipelineStage PipelineStage { get; set; }
        public bool IsWon { get; set; }
        public bool IsLost { get; set; }
        public DateTime ExpectedClosing { get; set; }
        public DateTime ActualClosing { get; set; }
        public LostReason LostReason { get; set; }

        public ICollection<OpportunityActivity> LineActivity { get; set; }
    }
}
