using Microsoft.EntityFrameworkCore;
using Neiria.Domain.Models;

namespace Neiria.Infrastructure.Context
{
  public class ClothContext : DbContext
  {
    public ClothContext(DbContextOptions<ClothContext> options)
        : base(options)
    {
      this.Database.EnsureCreated();
    }

    public DbSet<Cloth> Clothes { get; set; }

    public DbSet<Catergory> Catergories { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
