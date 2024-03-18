using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Infrastructure.Data.Models
{
    [Comment("Car to sell")]
    public class Vehicle
    {
        [Key]
        [Comment("Car Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Car location")]
        [MaxLength(CarLocationMaxLength)]
        public string CarLocation { get; set; } = string.Empty;

        [Required]
        [Comment("Car description")]
        [MaxLength(CarDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Car Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Car price")]
        [Range(typeof(decimal),CarMaxPrice, CarMinPrice,ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Car type Identifier")]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public VehicleType Type { get; set; } = null!;

        [Required]
        [Comment("Car seller Identifier")]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        [Required]
        [Comment("Car buyer Identifier")]
        public string? BuyerId { get; set; }

    }
}
