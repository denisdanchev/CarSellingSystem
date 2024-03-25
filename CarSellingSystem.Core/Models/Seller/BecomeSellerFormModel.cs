using System.ComponentModel.DataAnnotations;
using static CarSellingSystem.Core.Constants.MessageConstants;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Core.Models.Seller
{
    public class BecomeSellerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SellerPhoneNumberMaxLength,
            MinimumLength = SellerPhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null;
    }
}
