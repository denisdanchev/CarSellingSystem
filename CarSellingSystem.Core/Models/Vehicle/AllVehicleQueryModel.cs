using CarSellingSystem.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace CarSellingSystem.Core.Models.Vehicle
{
    public class AllVehicleQueryModel
    {
        public int VehiclesPerPage { get; } = 3;

        public string VehicleType { get; init; } = null!;


        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public VehicleSorting Sorting { get; set; }

        public int CurentPage { get; init; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<string> Types { get; set; } = null!;
        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>(); 




    }
}
