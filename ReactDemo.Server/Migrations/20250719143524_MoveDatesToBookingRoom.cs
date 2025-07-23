using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class MoveDatesToBookingRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "NumberAdults",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "NumberChildren",
                table: "Booking");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CheckInDate",
                table: "BookingRoom",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CheckOutDate",
                table: "BookingRoom",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "NumberAdults",
                table: "BookingRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberChildren",
                table: "BookingRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 7, 20), new DateOnly(2025, 7, 25), 2, 0 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 7, 28), new DateOnly(2025, 7, 31), 2, 1 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 7, 28), new DateOnly(2025, 7, 31), 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 1), new DateOnly(2025, 9, 10), 2, 0 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 8, 1), new DateOnly(2025, 8, 31), 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 1, 1 });

            migrationBuilder.UpdateData(
                table: "BookingRoom",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 16), new DateOnly(2025, 9, 20), 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "BookingRoom");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "BookingRoom");

            migrationBuilder.DropColumn(
                name: "NumberAdults",
                table: "BookingRoom");

            migrationBuilder.DropColumn(
                name: "NumberChildren",
                table: "BookingRoom");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CheckInDate",
                table: "Booking",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CheckOutDate",
                table: "Booking",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "NumberAdults",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberChildren",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 7, 20), new DateOnly(2025, 7, 25), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 7, 28), new DateOnly(2025, 7, 31), 2, 1 });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 8, 1), new DateOnly(2025, 8, 31), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 1), new DateOnly(2025, 9, 10), 2, 0 });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckInDate", "CheckOutDate", "NumberAdults", "NumberChildren" },
                values: new object[] { new DateOnly(2025, 9, 15), new DateOnly(2025, 9, 16), 1, 1 });
        }
    }
}
