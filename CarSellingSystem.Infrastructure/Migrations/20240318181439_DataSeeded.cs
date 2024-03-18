using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSellingSystem.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "29f87de2-4710-4e93-ba85-18edaa3fe6b6", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEKGbVZeEzwRg7ORgs7lIDVjlTW482u7QgXumPYqjkXzakfTSt1qZOOTxMlcDbNCHtw==", null, false, "547440fe-ec9f-4d3a-a51e-7552ef4093c7", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "ccd8fd6b-e4a2-48c4-b84c-4ad2ba660162", "seller@mail.com", false, false, null, "seller@mail.com", "seller@mail.com", "AQAAAAEAACcQAAAAEGnXuQpRCpji5TV0bmSzqtBEUwV4Af13Ih6nd3Hl5t+lXUYzH9U78F/nZQswGuP5TA==", null, false, "4ae42dd0-0998-4f06-b703-60d1665509de", false, "seller@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bus" },
                    { 2, "Car" },
                    { 3, "Motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BuyerId", "Description", "ImageUrl", "Price", "SellerId", "TypeId", "VehicleLocation" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "The condition is perfect. New tyres, new oil and filters.", "https://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpghttps://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpg", 11299.00m, 1, 3, "Sofia, BG(to the airport)" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BuyerId", "Description", "ImageUrl", "Price", "SellerId", "TypeId", "VehicleLocation" },
                values: new object[] { 2, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "The car is perfect. Two manths ago the steering rack was recycled and the rear suspension are changed.", "https://media.ed.edmunds-media.com/audi/a4/2010/oem/2010_audi_a4_wagon_20t-avant-premium-quattro_fq_oem_1_500.jpg", 15999.00m, 1, 2, "Burgas, BG(Knyazhevo)" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BuyerId", "Description", "ImageUrl", "Price", "SellerId", "TypeId", "VehicleLocation" },
                values: new object[] { 3, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "The car is perfect. Two manths ago the steering rack was recycled and the rear suspension are changed.", "https://st.mascus.com/imagetilewm/product/autocasiones/mercedes-benz-vito-tourer-116,5289716_1.jpg", 15999.00m, 1, 1, "Burgas, BG(Knyazhevo)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
