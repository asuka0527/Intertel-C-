using System;
using System.Collections.Generic;
using System.Text;
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



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
