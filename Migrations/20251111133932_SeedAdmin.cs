using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RII_USER_AUTHORITY",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 11, 11, 13, 39, 31, 406, DateTimeKind.Utc).AddTicks(5260), null, null, "User", null, null },
                    { 2L, null, new DateTime(2025, 11, 11, 13, 39, 31, 406, DateTimeKind.Utc).AddTicks(5593), null, null, "Manager", null, null },
                    { 3L, null, new DateTime(2025, 11, 11, 13, 39, 31, 406, DateTimeKind.Utc).AddTicks(5593), null, null, "Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "RII_USERS",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "IsActive", "IsEmailConfirmed", "LastLoginDate", "LastName", "PasswordHash", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1L, null, new DateTime(2025, 11, 11, 13, 39, 31, 416, DateTimeKind.Utc).AddTicks(7586), null, null, "admin@verii.com", "Admin", true, true, null, "User", "$2a$11$abcdefghijklmnopqrstuuNIZsBQfUYLG05oQWoW6wLHKeQreQYs6", null, null, null, 3L, null, null, "admin@v3rii.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RII_USERS",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RII_USER_AUTHORITY",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RII_USER_AUTHORITY",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RII_USER_AUTHORITY",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
