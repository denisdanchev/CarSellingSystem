using CarSellingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Seller> Sellers { get; set; } = null!;
        DbSet<Vehicle> Vehicles { get; set; } = null!;
        DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    }
}
