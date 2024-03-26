using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Core.Models.Vehicle;

namespace CarSellingSystem.Core.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicleAsync();
        Task<IEnumerable<VehicleTypesServiceModel>> AllTypesAsync();

        Task<bool> TypesExistsAsync(int typeId);
        Task<int> CeateAsync(VehicleFormModel model, int agentId);

    }
}
