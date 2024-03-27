using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Enumerations;
using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Core.Models.Vehicle;
using CarSellingSystem.Infrastructure.Data.Common;
using CarSellingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Numerics;

namespace CarSellingSystem.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<VehicleServiceQueryModel> AllAsync(string? type = null, string? searchedItem = null, VehicleSorting sorting = VehicleSorting.Newesst, int currentPade = 1, int vehiclesPerPage = 1)
        {
            var vehiclesToShow = repository.AllReadOnly<Vehicle>();

            if (type != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.Type.Name == type);
            }

            if (searchedItem != null)
            {
                string normalizseSearchTerm = searchedItem.ToLower();
                vehiclesToShow = vehiclesToShow
                    .Where(v => v.Title.ToLower().Contains(normalizseSearchTerm) ||
                           v.VehicleLocation.ToLower().Contains(normalizseSearchTerm) ||
                           v.Description.ToLower().Contains(normalizseSearchTerm));
            }

            vehiclesToShow = sorting switch
            {
                VehicleSorting.Price => vehiclesToShow.OrderBy(v => v.Price),
                VehicleSorting.NotSelledFirst => vehiclesToShow
                     .OrderBy(v => v.SellerId != null)
                     .ThenByDescending(v => v.Id),

                _ => vehiclesToShow
                    .OrderByDescending(v => v.Id)
            };

            var vehicles = await vehiclesToShow
                .Skip((currentPade - 1) * vehiclesPerPage)
                .Take(vehiclesPerPage)
                .Select(v => new VehicleServiceModel()
                {
                    Id= v.Id,
                    Location =  v.VehicleLocation,
                    ImageUrl = v.ImageUrl,
                    IsSelled = v.BuyerId != null,
                    Price = v.Price,
                    Title = v.Title
                }).ToListAsync();

            int totalVehicles = await vehiclesToShow.CountAsync();

            return new VehicleServiceQueryModel
            {
                Vehicle = vehicles,
                TotalVehiclesCount = totalVehicles,
            };
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<VehicleType>()
                .Select(t => t.Name)
                .Distinct()
                .ToListAsync();
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
