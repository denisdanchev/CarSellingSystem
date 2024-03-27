using CarSellingSystem.Core.Enumerations;
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

        Task<VehicleServiceQueryModel> AllAsync(
            string? type = null,
            string? searchedItem = null,
            VehicleSorting sorting = VehicleSorting.Newesst,
            int currentPade = 1,
                int vehiclesPerPage = 1
            );

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesBySellerId(int sellerId);
        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId(int userId);

        Task<bool> ExistsAsync(int id);

        Task<VehicleDetailsServiceModel> VehicleDetailsByIdAsync(int id);



    }
}
