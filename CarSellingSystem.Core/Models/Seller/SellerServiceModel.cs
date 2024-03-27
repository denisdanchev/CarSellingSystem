using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellingSystem.Core.Models.Seller
{
    public class SellerServiceModel
    {
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
