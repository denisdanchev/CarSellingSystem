using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Infrastructure.Data.Models
{
    [Comment("Car type")]
    public class VehicleType
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public List<Vehicle> Cars { get; set; } = new List<Vehicle>();
    }
}
