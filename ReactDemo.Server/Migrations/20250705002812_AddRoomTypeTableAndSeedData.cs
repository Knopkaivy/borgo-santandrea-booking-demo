using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomTypeTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BedsDescription",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SleepersCapacity",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "BasePrice", "BedsDescription", "Description", "Name", "Size", "SleepersCapacity" },
                values: new object[,]
                {
                    { 1, 750.00m, "1 Queen bed", "1 Queen bed or 2 Twin beds – 25sqm / 269sqft. Balcony or window. Coastal view", "Classic Courtyard", "25 sq m", 2 },
                    { 2, 850.00m, "1 Queen bed", "1 Queen bed or 2 Twin beds – From 32 to 36sqm / From 345 to 388sqft. Window – Juliet balcony. Lateral Sea view/coastal view", "Superior", "32 to 36 sq m", 2 },
                    { 3, 1075.00m, "1 Queen bed", "1 Large Queen bed or 2 Twin beds – From 35 to 40sqm / From 377 to 431sqft. Sitting area – Desk. Balcony. Sea view", "Deluxe with sea view balcony", "35 to 40 sq m", 2 },
                    { 4, 1400.00m, "1 King bed", "1 King bed or 2 Twin beds – From 45 to 55sqm / From 485 to 582sqft. Sitting area – Desk. Big window – Sea view", "Junior Suite", "45 to 55 sq m", 2 },
                    { 5, 2100.00m, "1 King bed", "1 King bed or 2 Twin beds – From 65 to 75sqm / From 700 to 807sqft. Separate sitting area – Desk. Big window – Sea view", "Corner Suite", "65 to 75 sq m", 3 },
                    { 6, 2275.00m, "1 King bed", "1 King bed or 2 Twin beds – From 107 to 120sqm / From 1151 to 1291sqft. Separate living area – Desk. Private terrace – Sea view", "Suite Deluxe with Terrace", "107 to 120 sq m", 3 },
                    { 7, 2325.00m, "1 King bed", "1 King bed – 90sqm / 968sqft. Separate sitting area – Private terrace – Sea view. Private heated infinity plunge pool", "Junior Suite sea view with Pool", "90 sq m", 2 },
                    { 8, 2470.00m, "1 King bed", "1 King or 2 Twin beds – From 85 to 105qm. Separate living area – Desk. Private terrace – Sea view. Private heated infinity plunge pool", "Suite Deluxe with Pool", "85 to 105 sq m", 3 },
                    { 9, 2850.00m, "1 Queen bed", "1 King bed or 2 Twin beds – 105sqm / 1131sqft. Sitting area – Desk. Private terrace or garden – Sea view. Private heated infinity plunge pool", "Premium Suite Pool", "105 sq m", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "BedsDescription",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "SleepersCapacity",
                table: "RoomType");
        }
    }
}
