using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFKBookingIdDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Booking_BookingId",
                table: "BookingRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Booking_BookingId",
                table: "BookingRoom",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Booking_BookingId",
                table: "BookingRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Booking_BookingId",
                table: "BookingRoom",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
