using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedDataForBookingAndBookingRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "GuestId", "NumberAdults", "NumberChildren" },
                values: new object[,]
                {
                    { 4, new DateOnly(2025, 9, 1), new DateOnly(2025, 9, 10), 1, 2, 0 },
                    { 5, new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 4, 1, 1 },
                    { 6, new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 4, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingId", "RoomId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "BookingRoom",
                columns: new[] { "Id", "BookingId", "RoomId" },
                values: new object[,]
                {
                    { 5, 3, 3 },
                    { 6, 5, 8 },
                    { 7, 6, 13 },
                    { 8, 6, 16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingId", "RoomId" },
                values: new object[] { 3, 27 });
        }
    }
}
