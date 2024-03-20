using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Infrastructure.Data;
using CarSellingSystem.Infrastructure.Data.Common;

namespace CarSellingSystem.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
