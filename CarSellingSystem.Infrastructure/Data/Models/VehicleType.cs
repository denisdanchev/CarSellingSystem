using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Infrastructure.Data.Models
{
    [Comment("Vehicle type")]
    public class VehicleType
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(VehicleTypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
