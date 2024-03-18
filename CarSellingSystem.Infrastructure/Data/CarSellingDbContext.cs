using CarSellingSystem.Infrastructure.Data.Models;
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
            builder.Entity<Vehicle>()
                .HasOne(v => v.Type)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(h => h.TypeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Vehicle>()
                .HasOne(v => v.Seller)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(h => h.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        DbSet<Seller> Sellers { get; set; } = null!;
        DbSet<Vehicle> Vehicles { get; set; } = null!;
        DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    }
}
