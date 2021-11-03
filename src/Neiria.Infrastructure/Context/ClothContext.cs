using Microsoft.EntityFrameworkCore;
using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Infrastructure.Context
{
  public class ClothContext : DbContext 
  {
    public ClothContext(DbContextOptions<ClothContext> options)
        : base(options)
    {
      this.Database.EnsureCreated();
    }

    public DbSet<Cloth> cloths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
