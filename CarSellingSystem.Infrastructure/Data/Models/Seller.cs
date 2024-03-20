using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarSellingSystem.Infrastructure.Constants.DataConstants;

namespace CarSellingSystem.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Vehicle seller")]
    public class Seller
    {
        [Key]
        [Comment("Seller Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Vehicle seller phone")]
        [MaxLength(SellerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
