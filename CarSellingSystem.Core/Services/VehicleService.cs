using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Core.Models.Vehicle;
using CarSellingSystem.Infrastructure.Data.Common;
using CarSellingSystem.Infrastructure.Data.Models;
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

        public async Task<IEnumerable<VehicleTypesServiceModel>> AllTypesAsync()
        {
            return await repository.AllReadOnly<VehicleType>()
                .Select(t => new VehicleTypesServiceModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task<int> CeateAsync(VehicleFormModel model, int agentId)
        {
            Vehicle vehicle = new Vehicle()
            {
               Title = model.Title,
               VehicleLocation = model.Location,
               Description = model.Description,
               ImageUrl = model.ImageUrl,
               Price = model.Price
            };

            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();

            return vehicle.Id;
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

        public async Task<bool> TypesExistsAsync(int typeId)
        {
            return await repository.AllReadOnly<VehicleType>()
                .AnyAsync(t => t.Id == typeId);
        }
    }
}
