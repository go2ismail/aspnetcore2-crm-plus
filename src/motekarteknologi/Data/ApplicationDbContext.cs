using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using motekarteknologi.Models;
using motekarteknologi.Areas.crm.Models;

namespace motekarteknologi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<motekarteknologi.Areas.crm.Models.ActivityType> ActivityType { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.Customer> Customer { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.CustomerActivity> CustomerActivity { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.CustomerAdditionalContact> CustomerAdditionalContact { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.CustomerNote> CustomerNote { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.CustomerType> CustomerType { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.Lead> Lead { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.LeadActivity> LeadActivity { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.LeadAdditionalContact> LeadAdditionalContact { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.LeadNote> LeadNote { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.LeadType> LeadType { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.LostReason> LostReason { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.Opportunity> Opportunity { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.OpportunityActivity> OpportunityActivity { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.PipelineStage> PipelineStage { get; set; }

        public DbSet<motekarteknologi.Areas.crm.Models.SalesChannel> SalesChannel { get; set; }

        
    }
}
