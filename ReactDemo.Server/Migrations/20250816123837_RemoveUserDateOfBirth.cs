using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserDateOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d980873-bba8-494d-bccd-9c382add5ce3", "AQAAAAIAAYagAAAAEPZEaOw5bWUvUveioHkeHYmoJIP7PrcTBSx7vUtm81lUWd07XzOFnfmXuc3OLjBAiA==", "29aa48e7-318c-4455-9979-1e2716517fc6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7d03d09-2aea-4996-9642-4cc626e94e70", new DateOnly(1991, 1, 1), "AQAAAAIAAYagAAAAEIYErJQQhAQG157H350XL91bmqNUPRQSQMlyn5i9J1W2mN9orUybutSKCiWjpdxp8g==", "af2b48c9-61ab-49f0-b32f-1773f9969627" });
        }
    }
}
