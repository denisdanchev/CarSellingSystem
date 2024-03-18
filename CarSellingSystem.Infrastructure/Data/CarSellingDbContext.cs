using CarSellingSystem.Infrastructure.Data.Models;
using CarSellingSystem.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Infrastructure.Data
{
    public class CarSellingDbContext : IdentityDbContext
    {
        public CarSellingDbContext(DbContextOptions<CarSellingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new VehicleTypeConfiguration());


            base.OnModelCreating(builder);
        }

        DbSet<Seller> Sellers { get; set; } = null!;
        DbSet<Vehicle> Vehicles { get; set; } = null!;
        DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    }
}
