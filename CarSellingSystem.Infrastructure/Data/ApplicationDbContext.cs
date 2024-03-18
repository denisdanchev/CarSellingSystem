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

        DbSet<Seller> Sellers { get; set; }
        DbSet<Vehicle> Cars { get; set; }
        DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
