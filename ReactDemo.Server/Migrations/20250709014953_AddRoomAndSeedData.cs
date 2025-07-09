using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 101, 1 },
                    { 2, 102, 1 },
                    { 3, 103, 1 },
                    { 4, 201, 2 },
                    { 5, 202, 2 },
                    { 6, 203, 2 },
                    { 7, 301, 3 },
                    { 8, 302, 3 },
                    { 9, 303, 3 },
                    { 10, 401, 4 },
                    { 11, 402, 4 },
                    { 12, 403, 4 },
                    { 13, 501, 5 },
                    { 14, 502, 5 },
                    { 15, 503, 5 },
                    { 16, 601, 6 },
                    { 17, 602, 6 },
                    { 18, 603, 6 },
                    { 19, 701, 7 },
                    { 20, 702, 7 },
                    { 21, 703, 7 },
                    { 22, 801, 8 },
                    { 23, 802, 8 },
                    { 24, 803, 8 },
                    { 25, 901, 9 },
                    { 26, 902, 9 },
                    { 27, 903, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
