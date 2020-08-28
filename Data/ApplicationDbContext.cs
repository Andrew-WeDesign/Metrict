using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Metrict.Models;

namespace Metrict.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignUser> CampaignUsers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<DeletedCampaign> DeletedCampaigns { get; set; }
        public DbSet<DeletedReport> DeletedReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<Campaign>().ToTable("Campaign");
            modelBuilder.Entity<CampaignUser>().ToTable("CampaignUser");
            modelBuilder.Entity<Report>().ToTable("Report");
            modelBuilder.Entity<DeletedCampaign>().ToTable("DeletedCampaign");
            modelBuilder.Entity<DeletedReport>().ToTable("DeletedReport");
            base.OnModelCreating(modelBuilder);
        }

    }
}
