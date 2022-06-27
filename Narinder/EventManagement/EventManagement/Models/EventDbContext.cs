using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EventManagement.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EventManagement.Models
{
    public partial class EventDbContext : DbContext
    {
        public EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                optionsBuilder.UseSqlServer("Data Source=tcp:eventmanagement3dbserver.database.windows.net,1433;Initial Catalog=EventManagement3_db;User Id=narinderkaur;Password=Nk12362889!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public virtual DbSet<Venue> Venue{ get; set; }
        public virtual DbSet<VenueDetails> VenueDetail { get; set; }
        public DbSet<EventManagement.Models.VenueAllDetails> VenueAllDetails { get; set; }
    }
}
