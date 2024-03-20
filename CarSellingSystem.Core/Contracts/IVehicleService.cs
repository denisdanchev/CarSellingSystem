using CarSellingSystem.Core.Models.Home;

namespace CarSellingSystem.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicleAsync();
    }
}
