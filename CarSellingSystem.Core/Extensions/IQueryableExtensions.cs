using CarSellingSystem.Core.Models.Vehicle;
using CarSellingSystem.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQueryableVehicleExtensions
    {
        public static IQueryable<VehicleServiceModel> ProjectToVehicleServiceModel(this IQueryable<Vehicle> vehicles)
        {
            return vehicles.Select(
                    v => new VehicleServiceModel()
                    { 
                        Id = v.Id,
                        Location = v.VehicleLocation,
                        ImageUrl = v.ImageUrl,
                        IsSelled = v.SellerId != null,
                        Price = v.Price,
                        Title = v.Title,
                    }
                );
        }
    }
}
