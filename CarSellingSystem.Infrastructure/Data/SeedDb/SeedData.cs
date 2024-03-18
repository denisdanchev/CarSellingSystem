using CarSellingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CarSellingSystem.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {

        public IdentityUser AgentUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Seller Seller { get; set; }
        public VehicleType Bus { get; set; }
        public VehicleType Car { get; set; }
        public VehicleType Motorcycle { get; set; }
        public Vehicle FirstVehicle { get; set; }
        public Vehicle SecondVehicle { get; set; }
        public Vehicle ThirdVehicle { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedCategories();
            SeedHouses();
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "seller@mail.com",
                NormalizedUserName = "seller@mail.com",
                Email = "seller@mail.com",
                NormalizedEmail = "seller@mail.com"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");
        }

        private void SeedAgent()
        {
            Seller = new Seller()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }

        private void SeedCategories()
        {
            Bus = new VehicleType()
            {
                Id = 1,
                Name = "Bus"
            };

            Car = new VehicleType()
            {
                Id = 2,
                Name = "Car"
            };

            Motorcycle = new VehicleType()
            {
                Id = 3,
                Name = "Motorcycle"
            };
        }

        private void SeedHouses()
        {
            FirstVehicle = new Vehicle()
            {
                Id = 1,
                VehicleLocation = "Sofia, BG(to the airport)",
                Description = "The condition is perfect. New tyres, new oil and filters.",
                ImageUrl = "https://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpghttps://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpg",
                Price = 11299.00M,
                TypeId = Motorcycle.Id,
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id
            };

            SecondVehicle = new Vehicle()
            {
                Id = 2,
                VehicleLocation = "Burgas, BG(Knyazhevo)",
                Description = "The car is perfect. Two manths ago the steering rack was recycled and the rear suspension are changed.",
                ImageUrl = "https://media.ed.edmunds-media.com/audi/a4/2010/oem/2010_audi_a4_wagon_20t-avant-premium-quattro_fq_oem_1_500.jpg",
                Price = 15999.00M,
                TypeId = Car.Id,
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id
            };

            ThirdVehicle = new Vehicle()
            {
                Id = 3,
                VehicleLocation = "Burgas, BG(Knyazhevo)",
                Description = "The car is perfect. Two manths ago the steering rack was recycled and the rear suspension are changed.",
                ImageUrl = "https://st.mascus.com/imagetilewm/product/autocasiones/mercedes-benz-vito-tourer-116,5289716_1.jpg",
                Price = 15999.00M,
                TypeId = Bus.Id,
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id
            };
        }

    }
}
