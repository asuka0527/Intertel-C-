using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Intertel.Entities;

namespace Intertel.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Disposition> Disposition { get; set; }
        public DbSet<ItemStatus> ItemStatus { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Agent> Agent { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemStatus>()
          .HasKey(m => new { m.ItemId, m.StatusId });
        }
    }
}
