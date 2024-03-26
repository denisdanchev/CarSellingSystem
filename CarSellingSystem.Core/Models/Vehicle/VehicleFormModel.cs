using System.ComponentModel.DataAnnotations;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;
using static CarSellingSystem.Core.Constants.MessageConstants;

namespace CarSellingSystem.Core.Models.Vehicle
{
    public class VehicleFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleLocationMaxLength,
            MinimumLength = VehicleLocationMinLength,
            ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleTitleMaxLength,
            MinimumLength = VehicleTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleDescriptionMaxLength,
            MinimumLength = VehicleDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Ïmage URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), 
            VehicleMinPrice, 
            VehicleMaxPrice,
            ConvertValueInInvariantCulture = true,
            ErrorMessage ="The price must be a positive number.")]
        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<VehicleTypesServiceModel> Types { get; set; } =
            new List<VehicleTypesServiceModel>();


    }
}
