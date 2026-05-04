using Microsoft.EntityFrameworkCore;
using VehicleManager.Domain.Entities;

namespace VehicleManager.Infrastructure.DataAccess;

public class VehicleManagerDbContext : DbContext
{
    public VehicleManagerDbContext(DbContextOptions options) : base(options) {}
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleManagerDbContext).Assembly);
    }
}