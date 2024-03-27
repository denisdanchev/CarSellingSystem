namespace CarSellingSystem.Core.Models.Vehicle
{
    public class VehicleServiceQueryModel
    {
        public int TotalVehiclesCount { get; set; }
        public IEnumerable<VehicleServiceModel> Vehicle { get; set; } = new List<VehicleServiceModel>();
    }
}
