using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Infrastructure.Data.Models
{
    [Comment("Vehicle to sell")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Vehicle location")]
        [MaxLength(VehicleLocationMaxLength)]
        public string VehicleLocation { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle description")]
        [MaxLength(VehicleDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle price")]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal),VehicleMaxPrice, VehicleMinPrice,ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Vehicle type Identifier")]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public VehicleType Type { get; set; } = null!;

        [Required]
        [Comment("Vehicle seller Identifier")]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        [Required]
        [Comment("Vehicle buyer Identifier")]
        public string? BuyerId { get; set; }

    }
}
