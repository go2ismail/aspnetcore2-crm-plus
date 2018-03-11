using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any activity type.
            if (context.ActivityType.Any())
            {
                return;   // DB has been seeded
            }

            context.ActivityType.Add(new Areas.crm.Models.ActivityType() { Name = "Call" });
            context.ActivityType.Add(new Areas.crm.Models.ActivityType() { Name = "Email" });
            context.ActivityType.Add(new Areas.crm.Models.ActivityType() { Name = "Meeting" });
            context.SaveChanges();

            context.LeadType.Add(new Areas.crm.Models.LeadType() { Name = "Government" });
            context.LeadType.Add(new Areas.crm.Models.LeadType() { Name = "Company" });
            context.LeadType.Add(new Areas.crm.Models.LeadType() { Name = "NGO" });
            context.LeadType.Add(new Areas.crm.Models.LeadType() { Name = "Education" });
            context.SaveChanges();

            context.LostReason.Add(new Areas.crm.Models.LostReason() { Name = "Too Expensive" });
            context.SaveChanges();

            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name="1. New Opportunity" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "2. Contacting" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "3. Engaging" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "4. Qualified" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "5. Demo Sample" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "6. Closing" });
            context.PipelineStage.Add(new Areas.crm.Models.PipelineStage() { Name = "7. Won / Lost" });
            context.SaveChanges();

            context.SalesChannel.Add(new Areas.crm.Models.SalesChannel() { Name = "Website" });
            context.SalesChannel.Add(new Areas.crm.Models.SalesChannel() { Name = "TV" });
            context.SalesChannel.Add(new Areas.crm.Models.SalesChannel() { Name = "Walkin" });
            context.SaveChanges();


        }
    }
}
