using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoleNameFrontDesk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0428efdd-bbf9-44fa-bba3-0a1873af0e56",
                column: "Name",
                value: "FrontDesk");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf6230be-2b81-4618-8973-4a324884d3f3", "AQAAAAIAAYagAAAAENfSHVUhlCtZrCJ0/RcMLmrCsJ+xOrmrlvE6ucFtFjOnypKF7lRAYbiuo4vOIdwQkg==", "a03c7407-c751-470c-80ed-32caf0b62838" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0428efdd-bbf9-44fa-bba3-0a1873af0e56",
                column: "Name",
                value: "Front Desk");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d980873-bba8-494d-bccd-9c382add5ce3", "AQAAAAIAAYagAAAAEPZEaOw5bWUvUveioHkeHYmoJIP7PrcTBSx7vUtm81lUWd07XzOFnfmXuc3OLjBAiA==", "29aa48e7-318c-4455-9979-1e2716517fc6" });
        }
    }
}
