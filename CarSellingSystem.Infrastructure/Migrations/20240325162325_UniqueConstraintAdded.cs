using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSellingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "317d940d-339d-4793-96a2-5a02279c7de8", "AQAAAAEAACcQAAAAENSlhT6gRkPI0kWlNbRZY3tT862DjXdLyQK5i8TH9cG3dSXzm41NGVPJWuiQKo7aEA==", "a7f1dd6e-9705-4688-b66e-9aedd2262784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bf424d2-9d0f-40a7-bf45-e11ea298e394", "AQAAAAEAACcQAAAAEOmsiMygqOKT8u3dNZnhIyipRxn9Da5e8z31xYd+cTsuJxKiiMv6gnC2f+baHMvZiQ==", "9f849c6a-4362-4bd5-b4df-8ae17c6a73e9" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Title" },
                values: new object[] { "https://www.gpone.com/sites/default/files/images/2020/article/foto/08/Moto%20-%20News/generic/hondacbr600rr-1598082277.jpg", "Honda CBR 600 2020" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Audi A4 QUATTRO");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Price", "Title", "VehicleLocation" },
                values: new object[] { "The bus is perfect. It has only 30000km on odometer.", 24999.00m, "Mercedes Vito w639", "St. Zagora, BG(Lipovo)" });

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_PhoneNumber",
                table: "Sellers",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sellers_PhoneNumber",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f7df1bd-b137-4106-b52c-51f7d8f9e371", "AQAAAAEAACcQAAAAED9nj1BOXMbJnHHaQEDBAY/DCqkqUO023I0NbxpB7ZVoCKh5NETF9s7gFawukNzUUw==", "ea0c1f04-ba36-4827-8743-cd59b45e96bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6da7dc99-b316-4e5a-b7de-ed1f278ec4ec", "AQAAAAEAACcQAAAAEE+mVFNR3JorEdvAGfQLsAcfhjCzEvJ799W8+eJfIBOEXEcbjJ/MWIIjHukAu4oGCQ==", "98ee743f-c28c-4104-9d58-74fcbc64de57" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Title" },
                values: new object[] { "https://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpghttps://en.wikipedia.org/wiki/Honda_CBR600RR#/media/File:2006HondaCBR600RR-001.jpg", "" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Price", "Title", "VehicleLocation" },
                values: new object[] { "The car is perfect. Two manths ago the steering rack was recycled and the rear suspension are changed.", 15999.00m, "", "Burgas, BG(Knyazhevo)" });
        }
    }
}
