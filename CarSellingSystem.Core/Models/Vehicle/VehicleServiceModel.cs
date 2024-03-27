using System.ComponentModel.DataAnnotations;
using static CarSellingSystem.Core.Constants.MessageConstants;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;


namespace CarSellingSystem.Core.Models.Vehicle
{
    public class VehicleServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleTitleMaxLength,
          MinimumLength = VehicleTitleMinLength,
          ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleLocationMaxLength,
            MinimumLength = VehicleLocationMinLength,
            ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Ïmage URL")]
        public  string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            VehicleMinPrice,
            VehicleMaxPrice,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "The price must be a positive number.")]
        [Display(Name = "Is selled")]
        public decimal Price { get; set; }

        

        public bool IsSelled { get; set; }
    }
}