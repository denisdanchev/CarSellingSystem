using CarSellingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSellingSystem.Infrastructure.Data.SeedDb
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
               .HasOne(v => v.Type)
               .WithMany(c => c.Vehicles)
               .HasForeignKey(h => h.TypeId)
               .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(v => v.Seller)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(h => h.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Vehicle[] { data.FirstVehicle, data.SecondVehicle, data.ThirdVehicle });
        }
    }
}
