using CarSellingSystem.Core.Models.Seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSellingSystem.Core.Models.Vehicle
{
    public class VehicleDetailsServiceModel : VehicleServiceModel
    {
        public string Description { get; set; } = null!;

        public string VehicleType { get; set; } = null!;

        public SellerServiceModel Seller { get; set; } = null!;

    }
}
