using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSellingSystem.Infrastructure.Migrations
{
    public partial class VehicleTitlaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Vehicles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Title");

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
                column: "Title",
                value: "");

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
                column: "Title",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29f87de2-4710-4e93-ba85-18edaa3fe6b6", "AQAAAAEAACcQAAAAEKGbVZeEzwRg7ORgs7lIDVjlTW482u7QgXumPYqjkXzakfTSt1qZOOTxMlcDbNCHtw==", "547440fe-ec9f-4d3a-a51e-7552ef4093c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccd8fd6b-e4a2-48c4-b84c-4ad2ba660162", "AQAAAAEAACcQAAAAEGnXuQpRCpji5TV0bmSzqtBEUwV4Af13Ih6nd3Hl5t+lXUYzH9U78F/nZQswGuP5TA==", "4ae42dd0-0998-4f06-b703-60d1665509de" });
        }
    }
}
