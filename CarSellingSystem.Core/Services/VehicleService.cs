using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicleAsync()
        {
            return await repository.
                AllReadOnly<Infrastructure.Data.Models.Vehicle>()
                .OrderByDescending(v => v.Id)
                .Take(3)
                .Select(v => new VehicleIndexServiceModel()
                {
                    Id = v.Id,
                    ImageUrl = v.ImageUrl,
                    Title = v.Title

                })
                .ToListAsync();
        }
    }
}
