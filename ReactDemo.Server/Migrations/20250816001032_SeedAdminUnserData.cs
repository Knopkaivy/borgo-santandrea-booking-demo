using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUnserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf", 0, "d7d03d09-2aea-4996-9642-4cc626e94e70", new DateOnly(1991, 1, 1), "admin@admin.com", true, "Borgo", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIYErJQQhAQG157H350XL91bmqNUPRQSQMlyn5i9J1W2mN9orUybutSKCiWjpdxp8g==", null, false, "af2b48c9-61ab-49f0-b32f-1773f9969627", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b117d060-6194-4e16-8c49-f60bbf42ec3e", "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b117d060-6194-4e16-8c49-f60bbf42ec3e", "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c4e17f-70dd-4aaa-bbc0-ac3fd88682bf");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
